﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetPro.Core.Infrastructure;
using NetPro.TypeFinder;
using Serilog;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NetPro.Grpc
{
    public class GrpcStartup : INetProStartup
    {
        public double Order { get; set; } = 0;

        public void Configure(IApplicationBuilder application)
        {
            application.UseRouting();

            application.UseEndpoints(endpoints =>
            {
                GrpcServiceExtension.AddGrpcServices(endpoints, new string[] { $"{Assembly.GetEntryAssembly().GetName().Name}" });
            });
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration = null, ITypeFinder typeFinder = null)
        {
            services.AddGrpc();

            //日志初始化配置
            services.ConfigureSerilogConfig(configuration);
        }
    }

    internal static class _Helper
    {
        /// <summary>
        /// 配置日志组件初始化
        /// </summary>
        /// <param name="configuration"></param>
        internal static void ConfigureSerilogConfig(this IServiceCollection services, IConfiguration configuration)
        {
            Serilog.Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(configuration)
              .CreateLogger();
        }
    }
}
