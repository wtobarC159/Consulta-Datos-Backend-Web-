using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Rest_Para_Consulta_de_Datos.Modelos;
using API_Rest_Para_Consulta_de_Datos.Dtos.Contribucion;

namespace API_Rest_Para_Consulta_de_Datos.Mapeador
{
    public static class ContribucionMap
    {
        public static ContribucionDTO ToContrDTO(this Contribucion ContModel) 
        {
            return new ContribucionDTO
            {
                Id = ContModel.Id,
                NombreContribucion = ContModel.NombreContribucion,
                Cantidad = ContModel.Cantidad,
                Contribuyentes = ContModel.Miembros.Select(m => m.ToMiembroDTOsim()).ToList()
            };
        }

        public static ContribucionDTOsim ToContrDTOsim(this Contribucion ContModel)
        {
            return new ContribucionDTOsim
            {
                Id = ContModel.Id,
                NombreContribucion = ContModel.NombreContribucion,
                Cantidad = ContModel.Cantidad
            };
        }

        public static Contribucion ToContribucion(this ContribucionCreateDTO ContModel) 
        {
            return new Contribucion
            {
                NombreContribucion = ContModel.NombreContribucion,
                Cantidad = ContModel.Cantidad
            };
        }
    }
}
