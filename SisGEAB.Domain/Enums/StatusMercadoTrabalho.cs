using System.ComponentModel.DataAnnotations;

namespace SisGEAB.Domain.Enums
{
    public enum StatusMercadoTrabalho
    {
        [Display(Name = "Nenhum(a)")]
        None = 0,
        [Display(Name = "Empregador(a)")]
        Empregador = 1,
        [Display(Name = "Assalariado com Carteira Assinada")]
        AssalariadoComCarteira = 2,
        [Display(Name = "Assalariado sem Carteira Assinada")]
        AssalariadoSemCarteira = 3,
        [Display(Name = "Autônomo com Previdência Social")]
        AutonomoComPrevidencia = 4,
        [Display(Name = "Autônomo sem Previdência Social")]
        AutonomoSemPrevidencia = 5,
        [Display(Name = "Aposentado/Pensinista")]
        AposentadoPesnionista = 6,
        [Display(Name = "Desempregado(a)")]
        Desempregado = 7,
        [Display(Name = "Não Trabalha")]
        NaoTrabalha = 8,
        [Display(Name = "Servidor Público/Militar")]
        ServidorPublicoMilitar = 9,
        [Display(Name = "Outro")]
        Outro = 10,
    }
}
