using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dominio.ValuesTypes
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumTipoUsuario
    {
        COLETOR = 1,
        DISTRIBUIDOR = 2,
    }
}
