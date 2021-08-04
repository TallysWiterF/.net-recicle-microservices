using System;

namespace Dominio.Entidades
{
    public abstract class Entity
    {
        public Guid Id { get; init; }
        public DateTime DataCriacao { get; init; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
