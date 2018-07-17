﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services.Implementations;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerInfoController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = new { Active = true };
            return Ok(result);
        }
    }
}
