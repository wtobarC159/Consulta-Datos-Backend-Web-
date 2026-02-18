using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using API_Rest_Para_Consulta_de_Datos.Dtos.Miembros;
using API_Rest_Para_Consulta_de_Datos.Dtos.Contribucion;
using API_Rest_Para_Consulta_de_Datos.Servicios;
using API_Rest_Para_Consulta_de_Datos.Interfaces;

namespace API_Rest_Para_Consulta_de_Datos.Mapeador
{
    public static class MiembrosMap
    {
        public static MiembroDTO ToMiembroDTO(this Miembro MiembroModel,RellenarRelacion Relacion)
        {
            return new MiembroDTO
            {
                Id = MiembroModel.Id,
                Nombres = MiembroModel.Nombres,
                Apellidos = MiembroModel.Apellidos,
                Edad = MiembroModel.Edad,
                FechaNacimiento = MiembroModel.FechaNacimiento,
                Rol = MiembroModel.Rol,
                Antiguedad = MiembroModel.Antiguedad,
                CI = MiembroModel.CI,
                Celular = MiembroModel.Celular,
                DepPortfolio = Relacion.ListDepartDTO(MiembroModel),
                Contribucion = MiembroModel.Contribuciones.Select(c => c.ToContrDTOsim()).ToList()
            };          
        }

        public static MiembroDTOsim ToMiembroDTOsim(this Miembro MiembroModel)
        {
            return new MiembroDTOsim
            {
                Id = MiembroModel.Id,
                Nombres = MiembroModel.Nombres,
                Apellidos = MiembroModel.Apellidos,
                Edad = MiembroModel.Edad,
                FechaNacimiento = MiembroModel.FechaNacimiento,
                Rol = MiembroModel.Rol,
                Antiguedad = MiembroModel.Antiguedad,
                CI = MiembroModel.CI,
                Celular = MiembroModel.Celular
            };
        }

        public static Miembro ToMiembro(this MiembroCreateDTO MiembroModel) 
        {
            return new Miembro
            {
                Nombres = MiembroModel.Nombres,
                Apellidos = MiembroModel.Apellidos,
                Edad = MiembroModel.Edad,
                FechaNacimiento = MiembroModel.FechaNacimiento,
                Departamentos = MiembroModel.Departamentos,
                Rol = MiembroModel.Rol,
                Antiguedad = MiembroModel.Antiguedad,
                CI = MiembroModel.CI,
                Celular = MiembroModel.Celular,
                Contribucion = MiembroModel.Contribucion
            };
        }
    }
}
