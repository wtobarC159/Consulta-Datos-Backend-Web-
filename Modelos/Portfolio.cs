using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Rest_Para_Consulta_de_Datos.Modelos
{
    [Table("Portfolios")]
    public class Portfolio
    {
        public int MiembroID { get; set; } 
        public Miembro Miembro { get; set; } 
        public int DepartamentoID { get; set; }
        public Departamento Departamento { get; set; }  
    }
}
