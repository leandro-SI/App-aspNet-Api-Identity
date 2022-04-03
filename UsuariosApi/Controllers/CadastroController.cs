using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Dtos;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {

        [HttpPost]
        public IActionResult CadastroUsuraio(CreateUsuarioDto usuarioDto)
        {

            return Ok();
        }

    }
}
