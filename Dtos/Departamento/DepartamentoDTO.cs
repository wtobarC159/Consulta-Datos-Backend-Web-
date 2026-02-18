using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using API_Rest_Para_Consulta_de_Datos.Dtos.Miembros;

namespace API_Rest_Para_Consulta_de_Datos.Dtos.Departamento
{
    public class DepartamentoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Lider { get; set; } = string.Empty;
        public string Colider { get; set; } = string.Empty;
        public int CantidadMiembros { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int TiempoExistencia { get; set; }

        public List<MiembroDTOsim> MiemPortfolio { get; set; }
    }
}
