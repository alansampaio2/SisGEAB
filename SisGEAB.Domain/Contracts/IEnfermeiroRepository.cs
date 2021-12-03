using SisGEAB.Domain.Models;
using SisGEAB.Domain.ViewModels.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisGEAB.Domain.Contracts
{
    public interface IEnfermeiroRepository
    {
        void Cadastrar(CadastrarEnfermeiroViewModel view);
    }
}
