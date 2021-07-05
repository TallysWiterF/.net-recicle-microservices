using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dominio.ValuesTypes
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumDiasDaSemana
    {
        Domingo = 0,
        Segunda = 1,
        Terca = 2,
        Quarta = 3,
        Quinta = 4,
        Sexta = 5,
        Sabado = 6,
    }
}
