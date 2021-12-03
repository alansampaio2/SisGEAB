using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SisGEAB.Domain.Models
{
    public static class Permissoes
    {
        public static ReadOnlyCollection<Permissao> TodasPermissoes;


        public const string NomeGrupoPermissoesUsuarios = "Permissões de Usuário";
        public static Permissao AcessarUsuarios = new Permissao("View Users", "acessar.usuario", NomeGrupoPermissoesUsuarios, "Permissão para ver os detalhes da conta de outros usuários");
        public static Permissao GerenciarUsuarios = new Permissao("Manage Users", "gerenciar.usuario", NomeGrupoPermissoesUsuarios, "Permissão para criar, excluir e modificar os detalhes da conta de outros usuários");

        public const string NomeGrupoPermissoesFuncoes = "Permissões de Função";
        public static Permissao AcessarFuncoes = new Permissao("Acessar Funções", "acessar.funcao", NomeGrupoPermissoesFuncoes, "Permissão para ver os papéis disponíveis");
        public static Permissao GerenciarFuncoes = new Permissao("Gerenciar Funções", "gerenciar.funcao", NomeGrupoPermissoesFuncoes, "Permissão para criar, excluir e modificar funções");
        public static Permissao AtribuirFuncoes = new Permissao("Atribuir Funções", "atribuir.funcao", NomeGrupoPermissoesFuncoes, "Permissão para atribuir funções aos usuários");


        static Permissoes()
        {
            List<Permissao> todasPermissoes = new List<Permissao>()
            {
                AcessarUsuarios,
                GerenciarUsuarios,

                AcessarFuncoes,
                GerenciarFuncoes,
                AtribuirFuncoes
            };

            TodasPermissoes = todasPermissoes.AsReadOnly();
        }

        public static Permissao SelecionarPermissaoPorNome(string nomePermissao)
        {
            return TodasPermissoes.Where(p => p.Nome == nomePermissao).SingleOrDefault();
        }

        public static Permissao SelecionarPermissaoPorValor(string valorPermissao)
        {
            return TodasPermissoes.Where(p => p.Valor == valorPermissao).SingleOrDefault();
        }

        public static string[] SelecionarTodasValoresPermissao()
        {
            return TodasPermissoes.Select(p => p.Valor).ToArray();
        }

        public static string[] SelecionarValoresPermissoesAdministrativas()
        {
            return new string[] { GerenciarUsuarios, GerenciarFuncoes, AtribuirFuncoes };
        }
    }
}
