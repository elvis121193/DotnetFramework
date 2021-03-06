﻿using Dotnet.Dependency;
using Dotnet.Serializing;

namespace Dotnet.Configurations
{
    public static class ConfigurationExtensions
    {
        /// <summary>使用Json4Net序列化
        /// </summary>
        public static Configuration UseJson4Net(this Configuration configuration)
        {
            var container = IocManager.GetContainer();
            container.Register<IJsonSerializer, NewtonsoftJsonSerializer>(DependencyLifeStyle.Transient);
            return configuration;
        }
    }
}
