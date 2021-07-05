using Aplicacao.Contratos;
using Dominio.ValuesTypes;
using Microsoft.AspNetCore.Http;
using NetDevPack.Identity.User;
using System;
using System.Linq;

namespace WebApi.Core.Implementacoes
{
    public class UsuarioRequisicao : IUsuarioRequisicao
    {
        private readonly IHttpContextAccessor _acessor;

        public UsuarioRequisicao(IHttpContextAccessor acessor)
        {
            _acessor = acessor;
        }
        public Guid Id() => Guid.Parse(_acessor.HttpContext.User.GetUserId());
        public EnumTipoUsuario TipoUsuario() => 
            Enum.Parse<EnumTipoUsuario>(_acessor.HttpContext.User.Claims.First(x => x.Type == "USUARIO").Value);
    }
}
