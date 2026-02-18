using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API_Rest_Para_Consulta_de_Datos.Dtos.Miembros
{
    public class MiembroUpdateDTO
    {
        [Required]
        [MaxLength(50,ErrorMessage = "El Nombre no puede sobrepasar los 50 caracteres")]
        public string Nombres { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "El Apellido no puede sobrepasar los 50 caracteres")]
        public string Apellidos { get; set; } = string.Empty;
        [Required]
        [Range(12, 99, ErrorMessage = "Ingrese una Fecha valida")]
        public int Edad { get; set; }
        [Required]
        ///<summary>Ingresar Fecha de Nacimiento en Formato dd/MM/yyyy</summary>
        public string FechaNacimiento { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "El o los departamentos no pueden sobrepasar los 100 caracteres")]
        ///<summary>Puede agregar mas de uno</summary>
        public string Departamentos { get; set; } = string.Empty;
        [Required]
        [MaxLength(15, ErrorMessage = "El Rol no puede sobrepasar los 15 caracteres")]
        ///<summary>El Rol puede ser 'LIDER', 'CO-LIDER', 'COLABORADOR','ASISTENTE'</summary>
        public string Rol { get; set; } = string.Empty;
        [Required]
        [Range(1, 12, ErrorMessage = "Ingrese una año de antiguedad valido")]
        ///<summary>En Años</summary>
        public int Antiguedad { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Ingrese un numero de identificacion valido")]
        public string CI { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "Ingresa un numero de celular valido")]
        public string Celular { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "Las contribucion no puede sobrepasar los 100 caracteres")]
        ///<summary> Puede ser 'PagoAires', 'PagoArreglos', 'PagoDepartamentos', puede agregar mas de uno</summary>
        public string Contribucion { get; set; } = string.Empty;

    }
}
