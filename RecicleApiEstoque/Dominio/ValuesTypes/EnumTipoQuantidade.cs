using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dominio.ValuesTypes
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumTipoQuantidade
    {
        Litro = 1,
        Quilo = 2
    }
}
