using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnimtaWebApi.Authorize
{

    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _policyName;

        public AuthorizationMiddleware(RequestDelegate next, string policyName)
        {
            _next = next;
            _policyName = policyName;
        }

        public async Task Invoke(HttpContext httpContext, IAuthorizationService authorizationService)
        {
            AuthorizationResult authorizationResult =
                await authorizationService.AuthorizeAsync(httpContext.User, null, _policyName);

            if (!authorizationResult.Succeeded)
            {
                await httpContext.ChallengeAsync();
                return;
            }

            await _next(httpContext);
        }
    }

    public static class AuthorizationApplicationBuilderExtensions
    {
        //public static IApplicationBuilder UseAuthorization(this IApplicationBuilder app, string policyName)
        //{
        //    return app.UseMiddleware(policyName);
        //}
        // Null checks removed for brevity
      
       
        }
    }





