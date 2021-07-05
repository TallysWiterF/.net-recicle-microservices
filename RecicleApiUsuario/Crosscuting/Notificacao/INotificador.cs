using System.Collections.Generic;

namespace Crosscuting.Notificacao
{
    public interface INotificador
    {
        void Add(string mensagem, EnumTipoMensagem tipo = EnumTipoMensagem.Warning);

        void AddRange(IReadOnlyList<string> mensagens, EnumTipoMensagem tipo);

        void Clear();

        bool Contain();

        IEnumerable<Mensagem> GetMensagens();
    }
}
