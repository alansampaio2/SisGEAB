using Microsoft.AspNetCore.Identity;
using SisGEAB.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisGEAB.Domain.Models
{
    public class Usuario : IdentityUser, IAuditableEntity
    {
        public virtual string NomeApresentacao
        {
            get
            {
                string friendlyName = string.IsNullOrWhiteSpace(NomeCompleto) ? UserName : NomeCompleto;

                if (!string.IsNullOrWhiteSpace(TituloProfissional))
                    friendlyName = $"{TituloProfissional} {friendlyName}";

                return friendlyName;
            }
        }

        public string CPF { get; set; }
        public string TituloProfissional { get; set; }
        public string NomeCompleto { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsLockedOut => this.LockoutEnabled && this.LockoutEnd >= DateTimeOffset.UtcNow;

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }



        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
    }
}
