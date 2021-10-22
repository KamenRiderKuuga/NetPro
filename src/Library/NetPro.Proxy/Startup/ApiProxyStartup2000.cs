﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetPro.Core.Infrastructure;
using NetPro.TypeFinder;
using NetPro.Proxy;

namespace NetPro.Proxy
{
    /// <summary>
    /// Proxy远程请求组件
    /// MicroServicesEndpoint:Assembly配置当前Proxy接口所在程序集名称
    /// </summary>
    public class ApiProxyStartup2000 : INetProStartup
    {
        public double Order { get; set; } = 0;

        public void Configure(IApplicationBuilder application)
        {
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration = null, ITypeFinder typeFinder = null)
        {
            services.AddHttpProxy(configuration, typeFinder, configuration.GetValue<string>("MicroServicesEndpoint:Assembly", string.Empty));
        }
    }
}
