using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BasicAuthDebug
{
    public class AuthenticationService
    {
        private readonly IServiceProvider _serviceProvider;

        public AuthenticationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            var dummyService = _serviceProvider.GetRequiredService<DummyService>();
            return true;
        }
 
    }
}