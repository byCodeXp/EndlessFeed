using System.Linq;
using Microsoft.AspNetCore.Http;

namespace API.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUserIdFromClaims(this HttpContext httpContext)
        {
            return httpContext.User.Claims.FirstOrDefault(claim => claim.Type == Env.IdentityClaims.ID)?.Value;
        }
    }
}