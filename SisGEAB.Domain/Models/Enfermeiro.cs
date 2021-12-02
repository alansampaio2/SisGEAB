using SisGEAB.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisGEAB.Domain.Models
{
    public class Enfermeiro : Pessoa
    {
        public string Matricula { get; set; }
        public Usuario Usuario { get; private set; }
        public string Coren { get; set; }
        public UF UF { get; set; }
    }
}
