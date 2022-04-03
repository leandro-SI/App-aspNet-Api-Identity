using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.GerenteDto;
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
    public class GerenteController : ControllerBase
    {
        private readonly GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto gerente = _gerenteService.Adicionar(gerenteDto);

            Console.WriteLine(gerente.Nome);

            return CreatedAtAction(nameof(RecuperaGerentePorId), new { id = gerente.Id }, gerente);
            
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            ReadGerenteDto gerente = _gerenteService.RecuperarPorId(id);

            if (gerente != null)
            {
                return Ok(gerente);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult RecuperaGerente()
        {
            List<ReadGerenteDto> gerentes = _gerenteService.Recuperar();

            if (gerentes != null)
            {
                return Ok(gerentes);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Result result = _gerenteService.Deletar(id);

            if (result.IsFailed)
                return NotFound();

            return NoContent();

        }
    }
}




