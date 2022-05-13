using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace ApiModulesExample
{
    public class ApiModuleFeatureProvider : ControllerFeatureProvider
    {
        private readonly bool condition;
        private readonly ApiModuleOptions options;

        public ApiModuleFeatureProvider(bool condition, ApiModuleOptions options)
        {
            this.condition = condition;
            this.options = options;
        }

        protected override bool IsController(TypeInfo typeInfo)
        {
            if (condition && options.DisabledControllers.Contains(typeInfo.Name))
            {
                return false;
            }
            return base.IsController(typeInfo);
        }
    }
}