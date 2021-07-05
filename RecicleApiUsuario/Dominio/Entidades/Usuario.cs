using Dominio.ValuesTypes;
using Microsoft.AspNetCore.Identity;
using System;

namespace Dominio.Entidades
{
    public class Usuario : IdentityUser, ICloneable
    {
        public EnumTipoUsuario Tipo { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
