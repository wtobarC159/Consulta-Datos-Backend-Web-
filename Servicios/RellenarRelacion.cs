using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using API_Rest_Para_Consulta_de_Datos.Data;
using API_Rest_Para_Consulta_de_Datos.Dtos.Departamento;
using Microsoft.EntityFrameworkCore;
using API_Rest_Para_Consulta_de_Datos.Mapeador;
using API_Rest_Para_Consulta_de_Datos.Dtos.Miembros;

namespace API_Rest_Para_Consulta_de_Datos.Servicios
{
    public class RellenarRelacion
    {
        private readonly Contexto _contexto;
        public RellenarRelacion(Contexto contexto) 
        {
            _contexto = contexto;
        }

        public  List<DepartamentDTOsim> ListDepartDTO(Miembro MiembroModels) 
        { 
            var Departamentos =  _contexto.Portfolios.Where(c => c.MiembroID == MiembroModels.Id).Select(Depart => new Departamento
            {
                Id = Depart.DepartamentoID,
                Nombre = Depart.Departamento.Nombre,
                Lider = Depart.Departamento.Lider,
                Colider = Depart.Departamento.Colider,
                CantidadMiembros = Depart.Departamento.CantidadMiembros,
                Descripcion = Depart.Departamento.Descripcion,
                TiempoExistencia = Depart.Departamento.TiempoExistencia
            }).ToList();

            var DepartDTOsim = Departamentos.Select(d => d.ToDeparDTOsim()).ToList();
            return DepartDTOsim;
        }

        public List<MiembroDTOsim> ListMiembroDTO(Departamento DepartModels) 
        { 
            var Miembros = _contexto.Portfolios.Where(e => e.DepartamentoID == DepartModels.Id).Select(Miemb => new Miembro
            {
                Id = Miemb.MiembroID,
                Nombres = Miemb.Miembro.Nombres,
                Apellidos = Miemb.Miembro.Apellidos,
                Edad = Miemb.Miembro.Edad,
                FechaNacimiento = Miemb.Miembro.FechaNacimiento,
                Departamentos = Miemb.Miembro.Departamentos,
                Rol = Miemb.Miembro.Rol,
                Antiguedad = Miemb.Miembro.Antiguedad,
                CI = Miemb.Miembro.CI,
                Celular = Miemb.Miembro.Celular,
                Contribucion = Miemb.Miembro.Contribucion
            }).ToList();

            var MiembDTOsim = Miembros.Select(f => f.ToMiembroDTOsim()).ToList();
            return MiembDTOsim;
        }

    }
}
