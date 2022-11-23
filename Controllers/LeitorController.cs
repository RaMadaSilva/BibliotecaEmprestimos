using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaEmprestimos.Controllers
{
    [ApiController]
    [Route("v1/leitor")]
    public class LeitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("web api");
        }

    }
}