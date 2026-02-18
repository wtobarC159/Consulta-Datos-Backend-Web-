using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using API_Rest_Para_Consulta_de_Datos.Dtos.Miembros;
using API_Rest_Para_Consulta_de_Datos.Helpers;
using API_Rest_Para_Consulta_de_Datos.Interfaces;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using API_Rest_Para_Consulta_de_Datos.Data;
using Microsoft.EntityFrameworkCore;
using API_Rest_Para_Consulta_de_Datos.Mapeador;

namespace API_Rest_Para_Consulta_de_Datos.Repositorio
{
    public class IMiembroRepositorio : IMiembro
    {
        private readonly Contexto _contexto;
        private readonly IPortfolio _portfolio;
        private readonly IContribucion _contribucion;

        public IMiembroRepositorio(Contexto contexto, IPortfolio portfolio, IContribucion contribucion)
        {
            _contexto = contexto;
            _portfolio = portfolio;
            _contribucion = contribucion;
        }

        public async Task<Miembro?> CreateMiembro(Miembro MiembroModel)
        {
            await _contexto.Miembros.AddAsync(MiembroModel);
            await _contexto.SaveChangesAsync();
            await _portfolio.CreatePortfolio(MiembroModel);
            await _contribucion.CreateMiembrosCont(MiembroModel);

            return MiembroModel;
        }

        public async Task<Miembro?> DeleteMiembro(int id)
        {
            var existingMiembro = await _contexto.Miembros.FirstOrDefaultAsync(m => m.Id == id);

            if (existingMiembro == null)
            {
                return null;
            }

            _contexto.Miembros.Remove(existingMiembro);
            await _contexto.SaveChangesAsync();
            return existingMiembro;
        }

        public async Task<List<Miembro>> GetAllMiembros(QueryObject Object)
        {
            var MiembroModel = _contexto.Miembros.Include(m => m.Portfolios).Include(m => m.Contribuciones).AsQueryable();
            if (!string.IsNullOrWhiteSpace(Object.DeparatmentoFilter))
            {
                MiembroModel = MiembroModel.Where(n => n.Departamentos.Contains(Object.DeparatmentoFilter));
            }

            if (!string.IsNullOrWhiteSpace(Object.ContribucionFilter))
            {
                MiembroModel = MiembroModel.Where(p => p.Contribucion.Contains(Object.ContribucionFilter));
            }

            return await MiembroModel.ToListAsync();

        }

        public async Task<Miembro?> GetbyIdMiembro(int id)
        {
            var existingMiembro = await _contexto.Miembros.Include(m => m.Portfolios).Include(n => n.Contribuciones).FirstOrDefaultAsync(m => m.Id == id);
            return existingMiembro;
        }

        public async Task<Miembro?> UpdateMiembro(int id, MiembroUpdateDTO MiembroModel)
        {
            var existingMiembro = await _contexto.Miembros.FirstOrDefaultAsync(m => m.Id == id);

            if (existingMiembro == null)
            {
                return null;
            }

            existingMiembro.Nombres = MiembroModel.Nombres;
            existingMiembro.Apellidos = MiembroModel.Apellidos;
            existingMiembro.Edad = MiembroModel.Edad;
            existingMiembro.FechaNacimiento = MiembroModel.FechaNacimiento;
            existingMiembro.Departamentos = MiembroModel.Departamentos;
            existingMiembro.Rol = MiembroModel.Rol;
            existingMiembro.Antiguedad = MiembroModel.Antiguedad;
            existingMiembro.CI = MiembroModel.CI;
            existingMiembro.Celular = MiembroModel.Celular;
            existingMiembro.Contribucion = MiembroModel.Contribucion;

            await _contexto.SaveChangesAsync();
            return existingMiembro;
        }
    }
}
