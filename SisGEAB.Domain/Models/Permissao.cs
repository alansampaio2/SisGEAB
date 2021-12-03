namespace SisGEAB.Domain.Models
{
    public class Permissao
    {
        public Permissao()
        { }

        public Permissao(string nome, string valor, string nomeGrupo, string descricao = null)
        {
            Nome = nome;
            Valor = valor;
            NomeGrupo = nomeGrupo;
            Descricao = descricao;
        }



        public string Nome { get; set; }
        public string Valor { get; set; }
        public string NomeGrupo { get; set; }
        public string Descricao { get; set; }


        public override string ToString()
        {
            return Valor;
        }


        public static implicit operator string(Permissao permissao)
        {
            return permissao.Valor;
        }
    }
}
