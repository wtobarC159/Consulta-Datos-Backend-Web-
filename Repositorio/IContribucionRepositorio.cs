using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using API_Rest_Para_Consulta_de_Datos.Interfaces;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using API_Rest_Para_Consulta_de_Datos.Helpers;
using API_Rest_Para_Consulta_de_Datos.Dtos.Contribucion;
using API_Rest_Para_Consulta_de_Datos.Data;
using Microsoft.EntityFrameworkCore;

namespace API_Rest_Para_Consulta_de_Datos.Repositorio
{
    public class IContribucionRepositorio : IContribucion
    {
        private readonly Contexto _contexto;

        public IContribucionRepositorio(Contexto contexto) 
        {
            _contexto = contexto;
        }
        public async Task<Contribucion?> CreateCont(Contribucion ContModel)
        {
            await _contexto.Contribuciones.AddAsync(ContModel);
            await _contexto.SaveChangesAsync();
            return ContModel;
        }

        public async Task CreateMiembrosCont(Miembro MiembroModel)
        {
            if (!string.IsNullOrWhiteSpace(MiembroModel.Contribucion))
            {
                if ((MiembroModel.Contribucion).ToLower().Contains("pago aires"))
                {
                    var Cont = await _contexto.Contribuciones.FirstOrDefaultAsync(m => m.NombreContribucion.ToLower() == "pago aires");
                    Cont.Miembros.Add(MiembroModel);
                    MiembroModel.Contribuciones.Add(Cont);
                }

                if ((MiembroModel.Contribucion).ToLower().Contains("pago arreglos"))
                {
                    var Cont = await _contexto.Contribuciones.FirstOrDefaultAsync(m => m.NombreContribucion.ToLower() == "pago arreglos");
                    Cont.Miembros.Add(MiembroModel);
                    MiembroModel.Contribuciones.Add(Cont);
                }

                if ((MiembroModel.Contribucion).ToLower().Contains("pago departamentos"))
                {
                    var Cont = await _contexto.Contribuciones.FirstOrDefaultAsync(m => m.NombreContribucion.ToLower() == "pago departamentos");
                    Cont.Miembros.Add(MiembroModel);
                    MiembroModel.Contribuciones.Add(Cont);
                }

                await _contexto.SaveChangesAsync();
            }
        }

        public async Task<Contribucion?> DeleteCont(int id)
        {
            var existingCont = await _contexto.Contribuciones.FirstOrDefaultAsync(m => m.Id == id);
            if (existingCont == null) return null;

            _contexto.Contribuciones.Remove(existingCont);
            await _contexto.SaveChangesAsync();
            return existingCont;
        }

        public async Task<List<Contribucion>> GetAllContribucion(QueryCont Object)
        {
            var existingCont =  _contexto.Contribuciones.Include(m => m.Miembros).AsQueryable();

            if (!string.IsNullOrWhiteSpace(Object.SortBy)) 
            {
                if (Object.SortBy.Equals("Cantidad", StringComparison.OrdinalIgnoreCase)) 
                { 
                    existingCont = Object.IsDescending ? existingCont.OrderByDescending(n => n.Cantidad) : existingCont.OrderBy(n => n.Cantidad);
                }
            }
            return await existingCont.ToListAsync();
            
        }

        public async Task<Contribucion?> GetbyIdCont(int id)
        {
            return await _contexto.Contribuciones.Include(m => m.Miembros).FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Contribucion?> UpdateCont(int id, ContribucionUpdateDTO ContModel)
        {
            var exisitngCont = await _contexto.Contribuciones.FirstOrDefaultAsync(m => m.Id == id);
            if (exisitngCont == null) return null;

            exisitngCont.NombreContribucion = ContModel.NombreContribucion;
            exisitngCont.Cantidad = ContModel.Cantidad;

            await _contexto.SaveChangesAsync();
            return exisitngCont;
        }
    }
}
