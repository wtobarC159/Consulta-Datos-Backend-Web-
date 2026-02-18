using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Rest_Para_Consulta_de_Datos.Modelos
{
    [Table("Departamentos")]
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Lider { get; set; } = string.Empty;
        public string Colider { get; set; } = string.Empty;
        public int CantidadMiembros { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int TiempoExistencia { get; set; } 

        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
