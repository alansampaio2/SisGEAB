using SisGEAB.Domain.Models;
using SisGEAB.Domain.ViewModels.Usuarios;
using System.Threading.Tasks;

namespace SisGEAB.Domain.Contracts
{
    public interface IEnfermeiroRepository
    {
        void Cadastrar(CadastrarEnfermeiroViewModel view);
        Task<Enfermeiro> SelecionarPorCPF(string CPF);
    }
}
