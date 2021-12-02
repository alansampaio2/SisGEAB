using System.ComponentModel.DataAnnotations;

namespace SisGEAB.Domain.Enums
{
    public enum IdentidadeGenero
    {
        [Display(Name = "Nenhum(a)")]
        None = 0,
        [Display(Name = "Homem Transsexual")]
        HomemTranssexual = 1,
        [Display(Name = "Mulher Transsexual")]
        MulherTranssexual = 2,
        [Display(Name = "Travesti")]
        Travesti = 3,
        [Display(Name = "Outro(a)")]
        Outro = 4
    }
}
