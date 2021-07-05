using System;

namespace Dominio.Entidades
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Entity()
        {
            DataCriacao = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public bool DataCriacaoIsValida() => DataCriacao <= DateTime.Now.AddMinutes(5) && DataCriacao >= DateTime.Now.AddMinutes(-5);

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
