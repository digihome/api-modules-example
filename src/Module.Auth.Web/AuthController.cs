using Microsoft.AspNetCore.Mvc;
using System;

namespace Module.Auth.Web
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {
        [HttpGet]
        public string Get()
        {
            var assembly = this.GetType().Assembly;
            return $"Hello from {assembly.FullName}, version {assembly.ImageRuntimeVersion}";
        }

        [HttpGet("version")]
        public string Version()
        {
            var assembly = this.GetType().Assembly;
            return assembly.ImageRuntimeVersion;
        }
    }
}
