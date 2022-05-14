using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DynamicLoadModulesExample
{
    public static class ApiModuleExtensions
    {
        public static IMvcBuilder AddApiModules(this IMvcBuilder builder, ApiModuleOptions? configure = null)
        {
            builder.ConfigureApplicationPartManager(p =>
            {
                var originals = p.FeatureProviders.OfType<ControllerFeatureProvider>().ToList();
                foreach (var original in originals)
                {
                    p.FeatureProviders.Remove(original);
                }
                p.FeatureProviders.Add(new ApiModuleFeatureProvider(true, configure));
            });
            ApiModuleList apiModules = new ApiModuleList();
            List<string> files = Energy.Base.Directory.GetAllFiles(@".", "Module.*.Web.dll").ToList();
            foreach (var file in files)
            {
                ApiModule module = new ApiModule();
                try
                {
                    string absolutePath = Energy.Base.File.GetAbsolutePath(file);
                    module.Path = absolutePath;
                    Assembly assembly = Assembly.LoadFrom(absolutePath);
                    string? name = assembly.GetName().Name;
                    module.Name =  name == null ? "unknown" : name;
                    module.Version = Energy.Core.Version.GetProduct(assembly);
                    module.Compilation = Energy.Core.Version.GetCompilation(assembly);
                    builder.AddApplicationPart(assembly);
                    module.Loaded = true;
                }
                catch (Exception ex)
                {
                    module.Loaded = false;
                    module.Error = ex.Message;
                }
                finally
                {
                    apiModules.Add(module);
                }
            }
            builder.Services.AddSingleton<ApiModuleList>(x => apiModules);
            return builder;
        }


    }
}
