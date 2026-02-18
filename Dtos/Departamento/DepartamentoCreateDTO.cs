using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace API_Rest_Para_Consulta_de_Datos.Dtos.Departamento
{
    public class DepartamentoCreateDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage ="El nombre del departmaento no debe acceder los 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage ="El nombre del lider no debe acceder los 50 caracteres")]
        public string Lider { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "El nombre del colider no debe acceder los 50 caracteres")]
        public string Colider { get; set; } = string.Empty;
        [Required]
        [Range(1,30, ErrorMessage = "La cantidad de personas no debe superar los 30 miembros")]
        public int CantidadMiembros { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "La descripcion no debe superar los 200 caracteres")]
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        [Range(1,12, ErrorMessage = "El tiempo de existencia no debe superar los 12 años")]
        public int TiempoExistencia { get; set; }
    }
}
