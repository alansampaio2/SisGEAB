using SisGEAB.Domain.Contracts;
using SisGEAB.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisGEAB.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly Contexto _contexto;

        IEnfermeiroRepository _enfermeiros;

        public UnitOfWork(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IEnfermeiroRepository Enfermeiros 
        {
            get
            {
                if (_enfermeiros == null)
                    _enfermeiros = new EnfermeiroRepository(_contexto);

                return _enfermeiros;
            }
        }

        public int SaveChanges()
        {
            return _contexto.SaveChanges();
        }
    }
}
