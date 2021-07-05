using Refit;
using System.Threading.Tasks;
using ViaCep.Objetos;

namespace ViaCep.Contratos
{
    public interface IGetEndereco
    {
        [Get("/ws/{cep}/json/")]
        Task<EnderecoResponse> GetEndereco(string cep);
    }
}
