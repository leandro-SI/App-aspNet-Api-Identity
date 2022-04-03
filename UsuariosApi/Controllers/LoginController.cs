using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Request;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService = null;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult LogarUsuario(LoginRequest request)
        {
            Result result = _loginService.Logar(request);

            if (result.IsFailed)
                return Unauthorized();

            return Ok();
        }
    }
}
