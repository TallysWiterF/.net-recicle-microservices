using MongoDB.Bson.Serialization.Attributes;
using Repositorio.Enums;
using System;

namespace Repositorio.Eventos
{
    internal class BaseEvento<T>
    {
        [BsonId]
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime DataInsercao { get; private set; } = DateTime.Now;
        public Guid IdEntidade { get; private set; }
        public T Entidade { get; private set; }
        public string NomeEntidade { get; private set; }
        public string TipoEvento { get; private set; }

        public static BaseEvento<T> Creator(Guid idEntidade, T entidade, EnumTipoEvento tipoEvento)
        {
            return new BaseEvento<T>()
            {
                IdEntidade = idEntidade,
                Entidade = entidade,
                NomeEntidade = entidade.GetType().Name,
                TipoEvento = tipoEvento.ToString(),
            };
        }
    }
}
