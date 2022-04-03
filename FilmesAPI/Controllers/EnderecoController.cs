using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.EnderecoDto;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService = null;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
           
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto endereroDto)
        {
            ReadEnderecoDto endereco = _enderecoService.Adicionar(endereroDto);

            Console.WriteLine(endereco.Logradouro);

            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { id = endereco.Id }, null);
        }

        [HttpGet]
        public IActionResult RecuperarEndereco()
        {
            List<ReadEnderecoDto> enderecos = _enderecoService.Recuperar();

            if (enderecos != null)
            {
                return Ok(enderecos);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPorId(int id)
        {
            ReadEnderecoDto endereco = _enderecoService.RecuperarPorId(id);

            if (endereco != null)
            {
                return Ok(endereco);
            }

            return NotFound();

        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result result = _enderecoService.Atualizar(id, enderecoDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarEndereco(int id)
        {

            Result result = _enderecoService.Deletar(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
