using System.ComponentModel.DataAnnotations;

namespace SisGEAB.Domain.Enums
{
    public enum OrientacaoSexual
    {
        [Display(Name = "Nenhum(a)")]
        None = 0,
        [Display(Name = "Heterossexual")]
        Heterossexual = 1,
        [Display(Name = "Homossexual")]
        Homossexual = 2,
        [Display(Name = "Bissexual")]
        Bissexual = 3,
        [Display(Name = "Outro(a)")]
        Outro = 4
    }
}
