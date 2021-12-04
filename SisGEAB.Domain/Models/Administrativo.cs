namespace SisGEAB.Domain.Models
{
    public class Administrativo : Pessoa
    {
        public string Matricula { get; set; }
        public Usuario Usuario { get; private set; }
    }
}
