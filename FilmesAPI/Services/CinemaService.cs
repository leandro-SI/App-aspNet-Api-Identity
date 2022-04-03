using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.CinemaDto;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        private readonly AppDbContext _context = null;
        private readonly IMapper _mapper = null;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto Adicionar(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> Recuperar(string nomeFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();

            if (cinemas == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(nomeFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeFilme)
                                            select cinema;

                cinemas = query.ToList();
            }

            return _mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto RecuperarPorId(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);

                return cinemaDto;
            }

            return null;
        }

        public Result Atualizar(int id, UpdateCinemaDto cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado.");
            }

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result Deletar(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if (cinema == null)
            {
                return Result.Fail("Erro ao Excluir.");
            }

            _context.Remove(cinema);
            _context.SaveChanges();

            return Result.Ok();
        }

    }
}
