using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API_Rest_Para_Consulta_de_Datos.Dtos.Usuarios
{
    public class NewUserDTO
    {
        public string Username { get; set;}
        public string Email { get; set;}
        public string Token { get; set;}
    }
}
