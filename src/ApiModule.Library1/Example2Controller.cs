using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiModuleLibrary1
{
    [ApiController]
    [Route("[controller]")]
    public class Example2Controller
    {
        [HttpGet]
        public string Get()
        {
            var assembly = this.GetType().Assembly;
            return $"Hello from {assembly.FullName}, version {assembly.ImageRuntimeVersion}";
        }
    }
}
