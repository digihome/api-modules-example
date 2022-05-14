using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicLoadModulesExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModulesController : ControllerBase
    {
        private readonly ILogger<ModulesController> _logger;
        private readonly ApplicationPartManager _partManager;
        private readonly ApiModuleList _apiModules;

        public ModulesController(ILogger<ModulesController> logger, ApplicationPartManager partManager, ApiModuleList apiModules)
        {
            _partManager = partManager;
            _logger = logger;
            _apiModules = apiModules;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var controllerFeature = new ControllerFeature();
            _partManager.PopulateFeature(controllerFeature);
            var modules =  controllerFeature.Controllers.ToList();
            return modules.Select(m => m.Name).ToList();
        }

        [HttpGet("apimodules")]
        public ApiModuleList ApiModules()
        {
            return _apiModules;
        }
    }
}
