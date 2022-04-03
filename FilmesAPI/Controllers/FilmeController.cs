using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
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
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _filmeService = null;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {

            ReadFilmeDto filme =  _filmeService.Adicionar(filmeDto);

            Console.WriteLine(filme.Titulo);

            return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? faixaEtaria = null)
        {
            List<ReadFilmeDto> filmes = _filmeService.Recuperar(faixaEtaria);

            if (filmes != null)
            {
                return Ok(filmes);
            }


            return NotFound();
        }


        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            ReadFilmeDto filme = _filmeService.RecuperarPorId(id);

            if (filme != null)
            {
                return Ok(filme);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result result = _filmeService.Atualizar(id, filmeDto);
            
            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Result result = _filmeService.Deletar(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}



