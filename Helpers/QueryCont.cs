using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API_Rest_Para_Consulta_de_Datos.Helpers
{
    public class QueryCont
    {
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
    }
}
