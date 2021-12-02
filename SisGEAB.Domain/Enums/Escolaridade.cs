using System.ComponentModel.DataAnnotations;

namespace SisGEAB.Domain.Enums
{
    public enum Escolaridade
    {
        [Display(Name = "Nenhum(a)")]
        None = 0,
        [Display(Name = "Alfabetizado(a)")]
        Alfabetizado = 1,
        [Display(Name = "Ensino Fundamental Completo")]
        FundamentalCompleto = 2,
        [Display(Name = "Ensino Fundamental Incompleto")]
        FundamentalIncompleto = 3,
        [Display(Name = "Ensino Médio Completo")]
        MedioCompleto = 4,
        [Display(Name = "Ensino Médio Incompleto")]
        MedioIncompleto = 5,
        [Display(Name = "Ensino Superior Completo")]
        SuperiorCompleto = 6,
        [Display(Name = "Ensino Superior Incompleto")]
        SuperiorIncompleto = 7,
        [Display(Name = "Pós-Graduação")]
        PosGraduacao = 8,
        [Display(Name = "Mestrado")]
        Mestrado = 9,
        [Display(Name = "Doutorado")]
        Doutorado = 10,
    }
}
