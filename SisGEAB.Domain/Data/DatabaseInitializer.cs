using Microsoft.Extensions.Logging;
using SisGEAB.Domain.Contracts;
using SisGEAB.Domain.Enums;
using SisGEAB.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisGEAB.Domain.Data
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }

    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly Contexto _context;
        private readonly IAccountManager _accountManager;
        //private readonly ILogger _logger;

        public DatabaseInitializer(Contexto context, IAccountManager accountManager)//, ILogger logger)
        {
            _context = context;
            _accountManager = accountManager;
            //_logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            const string _NomeFuncaoAdministrador = "Administrador";
            const string _NomeFuncaoEnfermeiro = "Enfermeiro";
            const string _NomeFuncaoEnfermeiroRT = "Enfermeiro Referencia Técnica";
            const string _NomeFuncaoACS = "Agente de Saúde";
            const string _NomeFuncaoPaciente = "Paciente";
            const string _NomeFuncaoAdministrativo = "Administrativo";

            await CadastrarFuncaoAsync(_NomeFuncaoAdministrador, "Acesso Total a Todas as Funções do Sistema", Permissoes.SelecionarTodasValoresPermissao());
            await CadastrarFuncaoAsync(_NomeFuncaoEnfermeiroRT, "Acesso Restrito a Funçoes Específicas Inerentes aos Resposáveis Técnicos", new string[] { });
            await CadastrarFuncaoAsync(_NomeFuncaoEnfermeiro, "Acesso Restrito a Funçoes Específicas Inerentes aos Enfermeiros", new string[] { });
            await CadastrarFuncaoAsync(_NomeFuncaoAdministrativo, "Acesso Restrito a Funçoes Específicas Inerentes aos Administrativos", new string[] { });
            await CadastrarFuncaoAsync(_NomeFuncaoACS, "Acesso Restrito a Funçoes Específicas Inerentes aos Agentes de Saúde", new string[] { });
            await CadastrarFuncaoAsync(_NomeFuncaoPaciente, "Acesso Restrito a Funçoes Específicas Inerentes aos Pacientes", new string[] { });

            var enfermeiroAdministrador = await CadastraUsuarioAsync("alansampaio", "Alan Mangueira Sampaio", "97519995534", "alanmangueira@gmail.com", "79999058203", new string[] { _NomeFuncaoAdministrador  });

            await CadastroEnfermeiroAsync(enfermeiroAdministrador, "Henilma Mangueira Sampaio", "José Fernando Sampaio", "1112222333344445555", new DateTime(1978, 7, 19), Sexo.Masculino, EstadoCivil.Casado, RacaCor.Preta, enfermeiroAdministrador.PhoneNumber, "121119", UF.SE, "402481");

        }

        private async Task<Usuario> CadastraUsuarioAsync(string nomeUsuario, string nome, string cpf, string email, string celular, string[] funcoes)
        {
            Usuario user = new Usuario
            {
                NomeCompleto = nome,
                UserName = nomeUsuario,
                CPF = cpf,
                Email = email,
                PhoneNumber = celular,
                EmailConfirmed = true,
                IsEnabled = true
            };

            var result = await _accountManager.CreateUserAsync(user, funcoes, cpf);

            var token = await _accountManager.GenerateEmailConfirmationTokenAsync(user);
            await _accountManager.ConfirmEmailAsync(user, token);

            if(!result.Succeeded)
                throw new Exception($"Seeding \"{email}\" user failed. Errors: {string.Join(Environment.NewLine, result.Errors)}");

            return user;
        }

        private async Task CadastrarFuncaoAsync(string nome, string descricao, string[] claims)
        {
            if ((await _accountManager.GetRoleByNameAsync(nome)) == null)
            {
                Funcao role = new Funcao(nome, descricao);

                var result = await this._accountManager.CreateRoleAsync(role, claims);

                if (!result.Succeeded)
                    throw new Exception($"Seeding \"{descricao}\" role failed. Errors: {string.Join(Environment.NewLine, result.Errors)}");
            }
        }

        private async Task CadastroEnfermeiroAsync(Usuario user, string mae, string pai, string cns, DateTime nascimento, Sexo sexo, 
            EstadoCivil estadoCivil, RacaCor racaCor, string celular, string coren, UF uf, string matricula)
        {
            if(!_context.Enfermeiros.Any())
            {
                var enfermeiro = new Enfermeiro
                {
                    Celular = celular,
                    CNS = cns,
                    Usuario = user,
                    UF = uf,
                    Coren = coren,
                    EstadoCivil = estadoCivil,
                    Mae = mae,
                    Pai = pai,
                    Nascimento = nascimento,
                    Matricula = matricula,
                    RacaCor = racaCor,
                    Sexo = sexo
                };

                _context.Enfermeiros.Add(enfermeiro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
