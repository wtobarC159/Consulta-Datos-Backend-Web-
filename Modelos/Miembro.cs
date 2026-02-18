using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Rest_Para_Consulta_de_Datos.Modelos
{
    [Table("Miembros")]
    public class Miembro
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string FechaNacimiento { get; set; } = string.Empty;
        public string Departamentos { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public int Antiguedad { get; set; }
        public string CI { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Contribucion { get; set; }= string.Empty;
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        public List<Contribucion> Contribuciones { get; set; } = new List<Contribucion>();
    }
}
