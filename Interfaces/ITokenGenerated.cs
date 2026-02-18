using API_Rest_Para_Consulta_de_Datos.Modelos;

namespace API_Rest_Para_Consulta_de_Datos.Interfaces
{
    public interface ITokenGenerated
    {
        string CreateToken(UsuarioAplicacion Usuario,string Role);
    }
}
