using SisGEAB.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisGEAB.Domain.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Mae { get; set; }
        public string Pai { get; set; }
        public string CNS { get; set; }
        public DateTime Nascimento { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public RacaCor RacaCor { get; set; }
        public string Celular { get; set; }

        public string DescricaoSexo()
        {
            string descricao = string.Empty;

            switch (Sexo)
            {
                case Sexo.Nome:
                    descricao = "Nenhum(a)";
                    break;
                case Sexo.Feminino:
                    descricao = "Feminino";
                    break;
                case Sexo.Masculino:
                    descricao = "Masculino";
                    break;
                default:
                    break;
            }
            return descricao;
        }

        public string DescricaoEstadoCivil()
        {
            string descricao = string.Empty;
            switch (EstadoCivil)
            {
                case EstadoCivil.None:
                    descricao = "Nenhum";
                    break;
                case EstadoCivil.Solteiro:
                    descricao = $"Solteir{SufixoDeGenero()}";
                    break;
                case EstadoCivil.UniaoEstavel:
                    descricao = "União Estável";
                    break;
                case EstadoCivil.Casado:
                    descricao = $"Casad{SufixoDeGenero()}";
                    break;
                case EstadoCivil.Divorciado:
                    descricao = $"Divorciad{SufixoDeGenero()}";
                    break;
                case EstadoCivil.Viuvo:
                    descricao = $"Viúv{SufixoDeGenero()}";
                    break;
                case EstadoCivil.Separado:
                    descricao = $"Separad{SufixoDeGenero()}";
                    break;
                default:
                    break;
            }
            return descricao;
        }

        public string DescricaoRacaCor()
        {
            string descricao = string.Empty;
            switch (RacaCor)
            {
                case RacaCor.None:
                    descricao = "Nenhum";
                    break;
                case RacaCor.Branca:
                    descricao = $"Branc{SufixoDeGenero()}";
                    break;
                case RacaCor.Preta:
                    descricao = $"Pret{SufixoDeGenero()}";
                    break;
                case RacaCor.Parda:
                    descricao = $"Pard{SufixoDeGenero()}";
                    break;
                case RacaCor.Amarela:
                    descricao = $"Amarel{SufixoDeGenero()}";
                    break;
                case RacaCor.Indigena:
                    descricao = "Indígena";
                    break;
                default:
                    break;
            }
            return descricao;
        }

        private string SufixoDeGenero()
        {
            var sufixo = string.Empty;
            switch (Sexo)
            {
                case Sexo.Nome:
                    sufixo = "";
                    break;
                case Sexo.Feminino:
                    sufixo = "a";
                    break;
                case Sexo.Masculino:
                    sufixo = "o";
                    break;
                default:
                    break;
            }

            return sufixo;
        }
    }
}
