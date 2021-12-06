using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisGEAB.Web.Models
{
    public class UsuarioPerfilViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<UserLoginInfo> Logins { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }

        public string CPF { get; set; }
        public string TituloProfissional { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
    }
}
