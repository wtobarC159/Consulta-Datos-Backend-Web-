using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using API_Rest_Para_Consulta_de_Datos.Dtos.Departamento;
using API_Rest_Para_Consulta_de_Datos.Servicios;

namespace API_Rest_Para_Consulta_de_Datos.Mapeador
{
    public static class DepartamentosMap
    {
        public static DepartamentoDTO ToDeparDTO(this Departamento DepModel,RellenarRelacion Relacion) 
        {
            return new DepartamentoDTO
            {
                Id = DepModel.Id,
                Nombre = DepModel.Nombre,
                Lider = DepModel.Lider,
                Colider = DepModel.Colider,
                CantidadMiembros = DepModel.CantidadMiembros,
                Descripcion = DepModel.Descripcion,
                TiempoExistencia = DepModel.TiempoExistencia,
                MiemPortfolio = Relacion.ListMiembroDTO(DepModel),
            };
        }

        public static DepartamentDTOsim ToDeparDTOsim(this Departamento DepModel) 
        {
            return new DepartamentDTOsim
            {
                Id = DepModel.Id,
                Nombre = DepModel.Nombre,
                Lider = DepModel.Lider,
                Colider = DepModel.Colider,
                CantidadMiembros = DepModel.CantidadMiembros,
                Descripcion = DepModel.Descripcion
            };
        }

        public static Departamento ToDepartamento(this DepartamentoCreateDTO DepModel)
        {
            return new Departamento
            {
                Nombre = DepModel.Nombre,
                Lider = DepModel.Lider,
                Colider = DepModel.Colider,
                CantidadMiembros = DepModel.CantidadMiembros,
                Descripcion = DepModel.Descripcion,
                TiempoExistencia = DepModel.TiempoExistencia
            };
        }
    }
}
