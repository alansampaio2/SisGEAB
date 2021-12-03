using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisGEAB.Web.Autorizacao
{
    public class Politicas
    {
        ///<summary>Policy to allow viewing all user records.</summary>
        public const string PoliticaAcessarTodosUsuarios = "Acessar Todos os Usuários";

        ///<summary>Policy to allow adding, removing and updating all user records.</summary>
        public const string PoliticaGerenciarTodosUsuarios = "Gerenciar Todos os Usuários";

        /// <summary>Policy to allow viewing details of all roles.</summary>
        public const string PoliticaAcessarTodasFuncoes = "Acessar Todos as Funções";

        /// <summary>Policy to allow viewing details of all or specific roles (Requires roleName as parameter).</summary>
        public const string PoliticaAcessarFuncoesPeloNome = "Acessar as Funções pelo Nome";

        /// <summary>Policy to allow adding, removing and updating all roles.</summary>
        public const string PoliticaGerenciarFuncoes = "Gerenciar Todas as Funções";

        /// <summary>Policy to allow assigning roles the user has access to (Requires new and current roles as parameter).</summary>
        public const string PoliticaAtribuirFuncoesPermitidas = "Atribuir Funções Permitidas";
    }

    /// <summary>
    /// Política de operação para permitir adicionar, visualizar, atualizar e excluir registros gerais ou específicos do usuário.
    /// </summary>
    public static class AccountManagementOperations
    {
        public const string CreateOperationName = "Create";
        public const string ReadOperationName = "Read";
        public const string UpdateOperationName = "Update";
        public const string DeleteOperationName = "Delete";

        public static UserAccountAuthorizationRequirement Create = new UserAccountAuthorizationRequirement(CreateOperationName);
        public static UserAccountAuthorizationRequirement Read = new UserAccountAuthorizationRequirement(ReadOperationName);
        public static UserAccountAuthorizationRequirement Update = new UserAccountAuthorizationRequirement(UpdateOperationName);
        public static UserAccountAuthorizationRequirement Delete = new UserAccountAuthorizationRequirement(DeleteOperationName);
    }
}
