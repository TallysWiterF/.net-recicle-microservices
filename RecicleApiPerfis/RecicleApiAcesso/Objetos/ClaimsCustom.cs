using System.Collections.Generic;

namespace RecicleApiAcesso.Objetos
{
    public class ClaimsCustom
    {
        public List<ClaimsCommand> Claims { get; set; }

        public ClaimsCustom()
        {
            Claims = new List<ClaimsCommand>();
        }
    }
    public class ClaimsCommand
    {
        public string Tipo { get; set; }
        public string Valor { get; set; }
    }
}
