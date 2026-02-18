using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using API_Rest_Para_Consulta_de_Datos.Dtos.Contribucion;
using API_Rest_Para_Consulta_de_Datos.Dtos.Departamento;

namespace API_Rest_Para_Consulta_de_Datos.Dtos.Miembros
{
    public class MiembroDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string FechaNacimiento { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public int Antiguedad { get; set; }
        public string CI { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;

        public List<DepartamentDTOsim> DepPortfolio { get; set; } 
        public List<ContribucionDTOsim> Contribucion { get; set; } 
    }
}
