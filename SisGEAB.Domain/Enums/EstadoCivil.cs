using System.ComponentModel.DataAnnotations;

namespace SisGEAB.Domain.Enums
{
    public enum EstadoCivil
    {
        [Display(Name = "Nenhum(a)")]
        None = 0,
        [Display(Name = "Solteiro(a)")]
        Solteiro = 1,
        [Display(Name = "União Estável")]
        UniaoEstavel = 2,
        [Display(Name = "Casado(a)")]
        Casado = 3,
        [Display(Name = "Divorciado(a)")]
        Divorciado = 4,
        [Display(Name = "Viúvo(a)")]
        Viuvo = 5,
        [Display(Name = "Separado(a)")]
        Separado = 6
    }
}
