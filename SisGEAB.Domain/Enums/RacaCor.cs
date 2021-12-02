using System.ComponentModel.DataAnnotations;

namespace SisGEAB.Domain.Enums
{
    public enum RacaCor
    {
        [Display(Name = "Nenhum(a)")]
        None = 0,
        [Display(Name = "Branco(a)")]
        Branca = 1,
        [Display(Name = "Preto(a)")]
        Preta = 2,
        [Display(Name = "Pardo(a)")]
        Parda = 3,
        [Display(Name = "Amarelo(a)")]
        Amarela = 4,
        [Display(Name = "Indígena")]
        Indigena = 5
    }
}
