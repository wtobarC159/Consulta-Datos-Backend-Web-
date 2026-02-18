using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using API_Rest_Para_Consulta_de_Datos.Helpers;
using API_Rest_Para_Consulta_de_Datos.Dtos.Contribucion;

namespace API_Rest_Para_Consulta_de_Datos.Interfaces
{
    
    public interface IContribucion
    {
        Task<List<Contribucion>> GetAllContribucion(QueryCont Object);
        Task<Contribucion?> GetbyIdCont(int id);
        Task<Contribucion?> CreateCont(Contribucion ContModel);
        Task CreateMiembrosCont(Miembro MiembroModel);
        Task<Contribucion?> UpdateCont(int id, ContribucionUpdateDTO ContModel);
        Task<Contribucion?> DeleteCont(int id);
    }
}
