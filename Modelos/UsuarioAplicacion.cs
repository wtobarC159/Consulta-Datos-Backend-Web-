using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Rest_Para_Consulta_de_Datos.Modelos
{
    [Table("Usuarios")]
    public class UsuarioAplicacion : IdentityUser {}
}
