using SisGEAB.Domain.Enums;

namespace SisGEAB.Domain.Models
{
    public class Enfermeiro : Pessoa
    {
        public string Matricula { get; set; }
        public Usuario Usuario { get; set; }
        public string Coren { get; set; }
        public UF UF { get; set; }

        public virtual string Conselho
        {
            get
            {
                return $"COREN-{UF} {Coren}";
            }
        }
    }
}
