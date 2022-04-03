using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.CinemaDto;
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
    public class CinemaController : ControllerBase
    {
        private readonly CinemaService _cinemaService = null;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
             
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto cinema = _cinemaService.Adicionar(cinemaDto);

            Console.WriteLine(cinema.Nome);

            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeFilme)
        {
            List<ReadCinemaDto> cinemas = _cinemaService.Recuperar(nomeFilme);

            if (cinemas == null)
            {
                return NotFound();
            }

            return Ok(cinemas);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int id)
        {
            ReadCinemaDto cinema = _cinemaService.RecuperarPorId(id);

            if (cinema == null)
            {
                return NotFound();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result result = _cinemaService.Atualizar(id, cinemaDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Result result = _cinemaService.Deletar(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
