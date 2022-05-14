using System.Collections.Generic;

namespace DynamicLoadModulesExample
{
    public class ApiModuleOptions
    {
        public List<string> DisabledControllers { get; set; } = new List<string>();
    }
}