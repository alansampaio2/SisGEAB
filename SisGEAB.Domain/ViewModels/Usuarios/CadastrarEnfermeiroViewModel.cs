using SisGEAB.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisGEAB.Domain.ViewModels.Usuarios
{
    public class CadastrarEnfermeiroViewModel
    {
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo CPF é obrigatório!")]
        [StringLength(11, ErrorMessage = "Campo CPF contém 11 números")]
        public string CPF { get; set; }

        [Display(Name = "Título Profissional")]
        [Required(ErrorMessage = "Campo CPF é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Máximo de caractere para Bairro é de 60")]
        [MinLength(2, ErrorMessage = "Mínimo de Caractere para Bairro é de 2.")]
        public string TituloProfissional { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Campo Nome é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Máximo de caractere para Bairro é de 150")]
        [MinLength(2, ErrorMessage = "Mínimo de Caractere para Bairro é de 2.")]
        public string NomeCompleto { get; set; }

        [Display(Name = "Nome Completo da Mãe")]
        [Required(ErrorMessage = "Campo Nome da Mãe é obrigatório!")]
        [MaxLength(150, ErrorMessage = "Máximo de caractere para Bairro é de 150")]
        [MinLength(2, ErrorMessage = "Mínimo de Caractere para Bairro é de 2.")]
        public string Mae { get; set; }

        [Display(Name = "Nome Completo do Pai")]
        public string Pai { get; set; }

        [Display(Name = "C.N.S")]
        [Required(ErrorMessage = "Campo CNS é obrigatório!")]
        [StringLength(11, ErrorMessage = "Campo CNS contém 15 números")]
        public string CNS { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo Data de Nascimento é obrigatório!")]
        public DateTime Nascimento { get; set; }

        [Display(Name = "Sexo")]
        public Sexo Sexo { get; set; }

        [Display(Name = "Estado Civil")]
        public EstadoCivil EstadoCivil { get; set; }

        [Display(Name = "Raça/Cor")]
        public RacaCor RacaCor { get; set; }

        [Display(Name = "Tel. Celular")]
        public string Celular { get; set; }

        [Display(Name = "Matricular")]
        [Required(ErrorMessage = "Campo Matrícula é obrigatório!")]
        [MaxLength(15, ErrorMessage = "Máximo de caractere para Matrícula é de 15")]
        [MinLength(2, ErrorMessage = "Mínimo de Caractere para Matrícula é de 2.")]
        public string Matricula { get; set; }

        [Display(Name = "COREN")]
        [Required(ErrorMessage = "Campo Coren é obrigatório!")]
        [MaxLength(15, ErrorMessage = "Máximo de caractere para Coren é de 15")]
        [MinLength(2, ErrorMessage = "Mínimo de Caractere para Coren é de 2.")]
        public string Coren { get; set; }

        [Display(Name = "UF")]
        [Required(ErrorMessage = "Campo UF é obrigatório!")]
        public UF UF { get; set; }
    }
}
