using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using SisGEAB.Domain.Models.Interfaces;

namespace SisGEAB.Domain.Models
{
    public class Funcao : IdentityRole, IAuditableEntity
    {
        public Funcao()
        {

        }

        public Funcao(string nome): base(nome)
        {

        }

        public Funcao(string nome, string descricao) : base(nome)
        {
            Descricao = descricao;
        }

        public string Descricao { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Usuarios { get; set; }
        
        public virtual ICollection<IdentityRoleClaim<string>> Claims { get; set; }
    }
}
