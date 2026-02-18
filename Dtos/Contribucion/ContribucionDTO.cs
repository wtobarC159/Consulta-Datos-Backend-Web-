using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using API_Rest_Para_Consulta_de_Datos.Dtos.Miembros;

namespace API_Rest_Para_Consulta_de_Datos.Dtos.Contribucion
{
    public class ContribucionDTO
    {
        public int Id { get; set; } 
        public string NombreContribucion { get; set; } = string.Empty;
        public double Cantidad { get; set; }

        public List<MiembroDTOsim> Contribuyentes { get; set; }
    }
}
