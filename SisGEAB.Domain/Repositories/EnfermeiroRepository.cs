using SisGEAB.Domain.Contracts;
using SisGEAB.Domain.Data;
using SisGEAB.Domain.Models;
using SisGEAB.Domain.ViewModels.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisGEAB.Domain.Repositories
{
    public class EnfermeiroRepository : IEnfermeiroRepository
    {
        protected readonly Contexto _contexto;

        public EnfermeiroRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Cadastrar(CadastrarEnfermeiroViewModel view)
        {
            throw new NotImplementedException();
        }
    }
}
