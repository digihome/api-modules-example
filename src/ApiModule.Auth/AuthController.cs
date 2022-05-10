using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiModule2
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
    }
}
