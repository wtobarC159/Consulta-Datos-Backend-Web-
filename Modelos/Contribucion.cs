using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Rest_Para_Consulta_de_Datos.Modelos
{
    [Table("Contribuciones")]
    public class Contribucion
    {
        public int Id { get; set; } 
        [Column("Contribucion")]
        public string NombreContribucion { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public double Cantidad { get; set; }

        public List<Miembro> Miembros { get; set; } = new List<Miembro>();
    }
}
