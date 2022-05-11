using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ApiModulesExample
{
    public static class ApiModulesExtensions
    {
        public static IMvcBuilder AddApiModules(this IMvcBuilder builder, Action<ApiModulesOptions>? configure = null)
        {
            Dictionary<string, Assembly> modules = new Dictionary<string, Assembly>();
            List<string> files = Energy.Base.Directory.GetAllFiles(@".", "ApiModule.*.dll").ToList();
            foreach (var file in files)
            {
                var module = Assembly.LoadFrom(Energy.Base.File.GetAbsolutePath(file));
                if (module != null && !modules.ContainsKey(module.GetName().Name))
                    modules.Add(module.GetName().Name, module);
            }

            foreach (var module in modules)
            {
                builder.AddApplicationPart(module.Value);
            }

            return builder;
        }


    }
}
