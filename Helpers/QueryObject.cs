using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API_Rest_Para_Consulta_de_Datos.Helpers
{
    public class QueryObject
    {
        public string? DeparatmentoFilter { get; set; } = null;
        public string? ContribucionFilter { get; set; } = null;
    }
}
