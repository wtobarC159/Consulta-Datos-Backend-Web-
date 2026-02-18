using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using API_Rest_Para_Consulta_de_Datos.Helpers;
using API_Rest_Para_Consulta_de_Datos.Dtos.Departamento;



namespace API_Rest_Para_Consulta_de_Datos.Interfaces
{
    public interface IDepartamento
    {
        Task<List<Departamento>> GetAllDept();
        Task<Departamento?> GetbyIdDept(int id);
        Task<Departamento?> CreateDept(Departamento DeptModel);
        Task<Departamento?> UpdateDept(int id, DepartamentoUpdateDTO DeptModel);
        Task<Departamento?> DeleteDept(int id);
    }
}
