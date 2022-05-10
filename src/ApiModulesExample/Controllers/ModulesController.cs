using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiModulesExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModulesController : ControllerBase
    {
        private readonly ILogger<ModulesController> _logger;
        private readonly ApplicationPartManager _partManager;


        public ModulesController(ILogger<ModulesController> logger, ApplicationPartManager partManager)
        {
            _partManager = partManager;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var controllerFeature = new ControllerFeature();
            _partManager.PopulateFeature(controllerFeature);
            var modules =  controllerFeature.Controllers.ToList();
            return modules.Select(m => m.Name).ToList();
        }
    }
}
