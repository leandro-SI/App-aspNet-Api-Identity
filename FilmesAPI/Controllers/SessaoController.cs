using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.SessaoDto;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto sessao = _sessaoService.Adicionar(sessaoDto);

            Console.WriteLine($"Add Sessão: {sessao.Id}");

            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { id = sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDto sessao = _sessaoService.RecuperarPorId(id);

            if (sessao != null)
            {
                return Ok(sessao);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult RecuperaSessoes()
        {
            var sessoes = _sessaoService.Recuperar();

            if (sessoes == null)
            {
                return NotFound();
            }

            return Ok(sessoes);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaSessao(int id)
        {
            Result result = _sessaoService.Deletar(id);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}
