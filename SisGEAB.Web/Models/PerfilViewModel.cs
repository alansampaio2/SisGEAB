namespace SisGEAB.Web.Models
{
    public class PerfilViewModel
    {
        public UsuarioPerfilViewModel Usuario { get; set; }
        public EnfermeiroPerfilViewModel Enfermeiro { get; set; } = null;
        public AgenteDeSaudePerfilViewModel ACS { get; set; } = null;
        public PacientePerfilViewModel Paciente { get; set; }
        public AdministrativoPerfilViewModel Administrativo { get; set; }
        public string Cargo { get; set; }
        public bool IsPaciente { get; set; } = false;
        public bool IsEnfermeiro { get; set; } = false;
        public bool IsAdministrativo { get; set; } = false;
        public bool IsAcs { get; set; } = false;
    }
}
