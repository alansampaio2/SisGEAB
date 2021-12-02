using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisGEAB.Domain.Models
{
    public class AgenteDeSaude : Pessoa
    {
        public string Matricula { get; set; }
        public Usuario Usuario { get; private set; }
    }
}
