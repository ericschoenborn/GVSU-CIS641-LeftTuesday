using LeftTuesday.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Controllers
{
    [Route("Display")]
    public class Displaycontroller : BaseController
    {
        private readonly DisplayService _displayService;

        public Displaycontroller(DisplayService displayService)
        {
            _displayService = displayService;
        }

        [HttpGet("concept/{id}")]
        public IActionResult GetFullConcept(long id)
        {
            return ReturnValueOrError(_displayService.GetFullConcept(id));
        }

        [HttpGet("everything/{id}")]
        public IActionResult GetEverythingt(long id)
        {
            return ReturnValueOrError(_displayService.GetEverything(id));
        }
    }
}
