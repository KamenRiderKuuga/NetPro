using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Test.Demo.Api
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
