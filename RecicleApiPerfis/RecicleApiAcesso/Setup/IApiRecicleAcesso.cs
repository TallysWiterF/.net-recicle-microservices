using System.Threading.Tasks;

namespace RecicleApiAcesso.Setup
{
    public interface IApiRecicleAcesso
    {
        Task<(TReturn Response, bool Sucesso)> PostAsync<TReturn, TContent>(string path, TContent content);
    }
}
