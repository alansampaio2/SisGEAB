using Microsoft.Extensions.Logging;

namespace SisGEAB.Web.Helpers
{
    public static class LoggingEvents
    {
        public static readonly EventId INIT_DATABASE = new EventId(101, "Erro ao criar e semear o banco de dados");
        public static readonly EventId SEND_EMAIL = new EventId(201, "Erro ao enviar e-mail");
    }
}
