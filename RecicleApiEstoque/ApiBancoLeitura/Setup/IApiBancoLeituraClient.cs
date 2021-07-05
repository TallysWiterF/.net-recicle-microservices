using System.Threading.Tasks;

namespace RecicleApiBancoLeitura.Setup
{
    public interface IApiBancoLeituraClient
    {
        Task<TReturn> GetAsync<TReturn, TFilter>(string path, TFilter filtro = null) where TFilter : class;
    }
}
