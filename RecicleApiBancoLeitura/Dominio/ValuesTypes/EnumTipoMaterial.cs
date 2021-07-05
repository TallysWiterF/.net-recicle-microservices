using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dominio.ValuesTypes
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumTipoMaterial
    {
        Liquido = 1,
        Solido = 2
    }
}
