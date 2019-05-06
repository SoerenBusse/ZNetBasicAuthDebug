using System;
using System.Net.Http;
using Microsoft.Extensions.Options;
using ZNetCS.AspNetCore.Authentication.Basic;

namespace BasicAuthDebug
{
    public class BasicAuthOptions : IConfigureNamedOptions<BasicAuthenticationOptions>
    {
        private readonly AuthenticationService _authenticationService;

        public BasicAuthOptions(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public void Configure(BasicAuthenticationOptions options)
        {
            throw new System.NotImplementedException();
        }

        public void Configure(string name, BasicAuthenticationOptions options)
        {
            switch (name)
            {
                case "Api":
                    ConfigureApiAuthentication(options);
                    break;
                default:
                    throw new ArgumentException($"Basic Authentication scheme {name} is unkown");
            }
        }

        private void ConfigureApiAuthentication(BasicAuthenticationOptions options)
        {
            options.Realm = "Api-Authentication";
            options.Events.OnValidatePrincipal = async context => {
                if (await _authenticationService.AuthenticateAsync(context.UserName, context.Password))
                {
                    context.Principal = context.HttpContext.User;
                }
            };
        }
    }
}