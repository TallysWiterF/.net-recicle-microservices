using Dominio.ValuesTypes;

namespace WebApi.Core.DTO
{
    public class UsuarioRegistroDTO
    {
        public string Email { get; init; }
        public EnumTipoUsuario Tipo { get; init; }
        public string Senha { get; init; }
    }

    public class UsuarioDTO : BaseDTO
    {
        public string Email { get; init; }
        public EnumTipoUsuario Tipo { get; init; }
    }
}
