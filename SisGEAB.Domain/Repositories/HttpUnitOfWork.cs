using Microsoft.AspNetCore.Http;
using SisGEAB.Domain.Core;
using SisGEAB.Domain.Data;

namespace SisGEAB.Domain.Repositories
{
    public class HttpUnitOfWork : UnitOfWork
    {
        public HttpUnitOfWork(Contexto context, IHttpContextAccessor httpAccessor) : base(context)
        {
            context.CurrentUserId = httpAccessor.HttpContext?.User.FindFirst(ClaimConstants.Subject)?.Value?.Trim();
        }
    }
}
