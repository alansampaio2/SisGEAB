using System.ComponentModel.DataAnnotations;

namespace SisGEAB.Web.Models
{
    public class LoginViewModel
    {
        /// <summary>
        /// Pode ser o Email ou o CPF
        /// </summary>
        [Required]
        public string NomeUsuario { get; set; }

        [Required]
        [MinLength(6)]
        public string Senha { get; set; }

        public bool Lembrarme { get; set; }
    }
}
