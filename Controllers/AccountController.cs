using API_Rest_Para_Consulta_de_Datos.Data;
using API_Rest_Para_Consulta_de_Datos.Dtos.Usuarios;
using API_Rest_Para_Consulta_de_Datos.Interfaces;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using API_Rest_Para_Consulta_de_Datos.Servicios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API_Rest_Para_Consulta_de_Datos.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UsuarioAplicacion> _userManager;
        private readonly SignInManager<UsuarioAplicacion> _signManager;
        private readonly ITokenGenerated _Token;
        private readonly RoleGenerated _Role;

        public AccountController(UserManager<UsuarioAplicacion> userManager, SignInManager<UsuarioAplicacion> signInManager, ITokenGenerated Token, RoleGenerated Role)
        {
            _userManager = userManager;
            _signManager = signInManager;
            _Token = Token;
            _Role = Role;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegistroUsuario([FromBody] RegisterDTO NuevoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var Usuario = new UsuarioAplicacion
                {
                    UserName = NuevoUsuario.Username,
                    PasswordHash = NuevoUsuario.Password,
                    Email = NuevoUsuario.Email,
                };

                var CrearUsuario = await _userManager.CreateAsync(Usuario, NuevoUsuario.Password);

                if (CrearUsuario.Succeeded)
                {
                    var RoleUsuario = _Role.Role(NuevoUsuario.Username);
                    var AsignarRole = await _userManager.AddToRoleAsync(Usuario, RoleUsuario);

                    if (AsignarRole.Succeeded)
                    {
                        return Ok(new NewUserDTO
                        {
                            Username = Usuario.UserName,
                            Email = Usuario.Email,
                            Token = _Token.CreateToken(Usuario, RoleUsuario)
                        });
                    }
                    else
                    {
                        return StatusCode(500, AsignarRole.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, CrearUsuario.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUsuario([FromBody] LoginDTO LoginUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var User = await _userManager.Users.FirstOrDefaultAsync(m => m.UserName == LoginUser.Username);

            if (User == null) return Unauthorized();

            var CheckPassword = await _signManager.CheckPasswordSignInAsync(User, LoginUser.Password, false);

            if (!CheckPassword.Succeeded) return Unauthorized("El nombre de usuario o la contraseña son incorrectos");

            var RoleUsuario = await _userManager.GetRolesAsync(User);

            return Ok(new NewUserDTO
            {
                Username = User.UserName,
                Email = User.Email,
                Token = _Token.CreateToken(User, RoleUsuario[0]),
            });
        }
    }
}
