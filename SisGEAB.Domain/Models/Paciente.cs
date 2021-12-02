using SisGEAB.Domain.Enums;
using System;

namespace SisGEAB.Domain.Models
{
    public class Paciente : Pessoa
    {
        public Usuario Usuario { get; set; }
        public string Ocupacao { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public StatusMercadoTrabalho StatusMercadoTrabalho { get; set; }
        public bool PlanoSaudePrivado { get; set; }
        public OrientacaoSexual OrientacaoSexual { get; set; }
        public IdentidadeGenero IdentidadeGenero { get; set; }
        public bool Obito { get; set; } = false;
        public DateTime? DataObito { get; set; }
        public string NumeroDeclaracaoObito { get; set; }

        //protected Paciente()
        //{

        //}

        //public Paciente(string cpf, string tituloProfissional, string nome, string mae, string pai, string cns, DateTime nascimento,
        //    Sexo sexo, EstadoCivil estadoCivil, RacaCor racaCor, string celular, string ocupacao, Escolaridade escolaridade,
        //    StatusMercadoTrabalho statusMercadoTrabalho, string planoSaudePrivado, OrientacaoSexual orientacaoSexual,
        //    IdentidadeGenero identidadeGenero)
        //{
        //    Usuario.CPF = cpf;
        //    Usuario.TituloProfissional = tituloProfissional;
        //    Usuario.NomeCompleto = nome;
        //    Mae = mae;
        //    Pai = pai;
        //    CNS = cns;
        //    Nascimento = nascimento;
        //    Sexo = sexo;
        //    EstadoCivil = estadoCivil;
        //    RacaCor = racaCor;
        //    Celular = celular;
        //    Ocupacao = ocupacao;
        //    Escolaridade = escolaridade;
        //    IdentidadeGenero = identidadeGenero;
        //}
    }
}
