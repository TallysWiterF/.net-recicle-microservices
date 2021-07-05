using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Repositorio.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    internal enum EnumTipoEvento
    {
        Adicao = 1,
        Atualizacao = 2,
        Remocao = 3
    }
}
