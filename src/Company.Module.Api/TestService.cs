using Microsoft.Extensions.Configuration;

namespace Company.Module.Api
{
    public class TestService : ITestService
    {
        private readonly IConfiguration _Configuration;
        public TestService(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        public string GetName()
        {
            return _Configuration.GetValue<string>("AllowedHosts");
        }
    }
}
