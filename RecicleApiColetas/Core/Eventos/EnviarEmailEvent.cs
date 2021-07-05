using Core.Base;
using Core.Objetos;

namespace Core.Eventos
{
    public class EnviarEmailEvent : BaseEvent
    {
        public Email Email { get; set; }

        public EnviarEmailEvent(Email email)
        {
            Email = email;
        }
    }
}
