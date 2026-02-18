using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using API_Rest_Para_Consulta_de_Datos.Modelos;

namespace API_Rest_Para_Consulta_de_Datos.Interfaces
{
    public interface IPortfolio
    {
        Task<List<Departamento>> GetPortfolio(int idMiembro);
        Task CreatePortfolio(Miembro MiemPortfolio);
        Task<Portfolio?> AddPortfolio(int idMiembro, string Departamento);
        Task<Portfolio?> DeletePortfolio(int id, string departamento);
        
    }
}
