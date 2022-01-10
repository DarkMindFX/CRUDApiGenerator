using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.IdentityModel.Tokens;
using PPT.Services.Common.Helpers;
using PPT.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PPT.Services.Common.Exceptions;

namespace PPT.Functions.Common
{
    public class AuthorizeAttribute : FunctionInvocationFilterAttribute
    {
        private const string AuthenticationHeaderName = "Authorization";

        public override async Task OnExecutingAsync(FunctionExecutingContext executingContext, CancellationToken cancellationToken)
        {
            HttpRequest request = (HttpRequest)executingContext.Arguments["req"];

            if (request == null || !request.Headers.ContainsKey(AuthenticationHeaderName))
            {
                throw new UnauthorizedException("No Authorization header was present");
            }

            var funHelper = new FunctionHelper();
            var dalUsers = request.HttpContext.RequestServices.GetRequiredService<PPT.Services.Dal.IUserDal>();

            var secret = funHelper.GetEnvironmentVariable<string>(Constants.ENV_JWT_SECRET);
            var token = JWTHelper.GetAuthToken(request);

            var currentUser = JWTHelper.GetUserFromToken(token, secret, dalUsers);
            request.HttpContext.Items["User"] = currentUser;

            if(currentUser == null)
            {
                request.HttpContext.Response.StatusCode = 401;
                await request.HttpContext.Response.Body.FlushAsync();
                request.HttpContext.Response.Body.Close();
                throw new UnauthorizedException("No user was found for given authentication token");
            }
        }
    }
}
