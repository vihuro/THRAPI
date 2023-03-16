using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace ThrApi.Service.JWT
{
    public class CustomAuthorize
    {
        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
        {

            var permissions = claimValue.Split(',');


            if(context.User.Identity.IsAuthenticated &&
                context.User.Claims.Any(c => c.Type == claimName)) { 
                for(int i =0; i< permissions.Length; i++)
                {
                    if(context.User.Claims.Any(x => x.Value == permissions[i].ToString()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
    public class ClaimsAuthorizeAttibute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttibute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }


    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;
        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {

                context.Result = new StatusCodeResult(401);
                return;
            }
            if (!CustomAuthorize.ValidarClaimsUsuario(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
