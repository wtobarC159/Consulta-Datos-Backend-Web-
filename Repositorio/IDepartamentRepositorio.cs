using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using API_Rest_Para_Consulta_de_Datos.Interfaces;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using API_Rest_Para_Consulta_de_Datos.Helpers;
using API_Rest_Para_Consulta_de_Datos.Dtos.Departamento;
using API_Rest_Para_Consulta_de_Datos.Data;
using Microsoft.EntityFrameworkCore;

namespace API_Rest_Para_Consulta_de_Datos.Repositorio
{
    public class IDepartamentRepositorio : IDepartamento
    {
        private readonly Contexto _contexto;

        public IDepartamentRepositorio(Contexto contexto) 
        {
            _contexto = contexto;
        }
        public async Task<Departamento?> CreateDept(Departamento DeptModel)
        {
            await _contexto.Departamentos.AddAsync(DeptModel);
            await _contexto.SaveChangesAsync();
            return DeptModel;
        }

        public async Task<Departamento?> DeleteDept(int id)
        {
            var existingDept = await _contexto.Departamentos.FirstOrDefaultAsync(m => m.Id == id);

            if (existingDept == null) return null;

            _contexto.Departamentos.Remove(existingDept);
            await _contexto.SaveChangesAsync();
            return existingDept;
        }

        public async Task<List<Departamento>> GetAllDept()
        {
            var exisitingDepts = await _contexto.Departamentos.Include(m => m.Portfolios).ToListAsync();
            return exisitingDepts;
        }

        public async Task<Departamento?> GetbyIdDept(int id)
        {
            return await _contexto.Departamentos.Include(m => m.Portfolios).FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Departamento?> UpdateDept(int id, DepartamentoUpdateDTO DeptModel)
        {
            var existingDept = await _contexto.Departamentos.FirstOrDefaultAsync(m => m.Id == id);
            if (existingDept == null) return null;

            existingDept.Nombre = DeptModel.Nombre;
            existingDept.Lider = DeptModel.Lider;
            existingDept.Colider = DeptModel.Colider;
            existingDept.CantidadMiembros = DeptModel.CantidadMiembros;
            existingDept.Descripcion = DeptModel.Descripcion;
            existingDept.TiempoExistencia = DeptModel.TiempoExistencia;

            await _contexto.SaveChangesAsync();
            return existingDept;
        }
    }
}
