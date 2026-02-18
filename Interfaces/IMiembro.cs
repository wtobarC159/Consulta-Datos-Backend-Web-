using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using API_Rest_Para_Consulta_de_Datos.Helpers;
using API_Rest_Para_Consulta_de_Datos.Dtos.Miembros;


namespace API_Rest_Para_Consulta_de_Datos.Interfaces
{
    public interface IMiembro
    {
        Task<List<Miembro>> GetAllMiembros(QueryObject Object);
        Task<Miembro?> GetbyIdMiembro(int id);
        Task<Miembro?> CreateMiembro(Miembro MiembroModel);
        Task<Miembro?> UpdateMiembro(int id, MiembroUpdateDTO MiembroModel);
        Task<Miembro?> DeleteMiembro(int id);
    }
}
