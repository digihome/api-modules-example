using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Module.Library.Web
{
    [ApiController]
    [Route("[controller]")]
    public class Example1Controller
    {
        [HttpGet]
        public string Get()
        {
            var assembly = this.GetType().Assembly;
            return $"Hello from {assembly.FullName}, version {assembly.ImageRuntimeVersion}";
        }
    }
}
