using API_Rest_Para_Consulta_de_Datos.Dtos.Miembros;

namespace API_Rest_Para_Consulta_de_Datos.Dtos.Contribucion
{
    public class ContribucionDTOsim
    {
        public int Id { get; set; } 
        public string NombreContribucion { get; set; } = string.Empty;
        public double Cantidad { get; set; }
    }
}
