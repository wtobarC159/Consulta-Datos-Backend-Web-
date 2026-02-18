using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Rest_Para_Consulta_de_Datos.Dtos.Contribucion
{
    public class ContribucionCreateDTO
    {
        [Required]
        [MaxLength(50,ErrorMessage = "El nombre de la contribucion no debe superar los 50 caracteres")]
        public string NombreContribucion { get; set; } = string.Empty;
        [Required]
        [Range(0.01, 100, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public double Cantidad { get; set; }
    }
}
