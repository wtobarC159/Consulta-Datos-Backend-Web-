using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using API_Rest_Para_Consulta_de_Datos.Data;

namespace API_Rest_Para_Consulta_de_Datos.Servicios
{
    public class RoleGenerated
    {
        private readonly Contexto _contexto;

        public RoleGenerated(Contexto contexto) 
        {
            _contexto = contexto;
        }

        public string Role(string UserName) 
        {
            var MiembroRegister = _contexto.Departamentos.FirstOrDefault(m => m.Lider == UserName);

            if (MiembroRegister != null)
            {
                return "Admin";
            }
            else 
            {
                return "User";
            }
        }
    }
}
