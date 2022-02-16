﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace NetPro.Tdengine
{
    /// <summary>
    /// TaosOption配置
    /// </summary>
    public class TaosOption
    {
        /// <summary>
        /// 
        /// </summary>
        public TaosOption()
        {
        }

        /// <summary>
        /// root node is Redis
        /// </summary>
        /// <param name="config"></param>
        public TaosOption(IConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            config.GetSection(nameof(TaosOption)).Bind(this);
        }

        /// <summary>
        /// 连接串集合
        /// </summary>
        public List<ConnectionString> ConnectionString { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class ConnectionString
    {
        /// <summary>
        /// 连接串别名
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 连接串
        /// </summary>
        public string Value { get; set; }
    }
}