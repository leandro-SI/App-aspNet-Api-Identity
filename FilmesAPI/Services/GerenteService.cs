using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.GerenteDto;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private readonly AppDbContext _context = null;
        private readonly IMapper _mapper = null;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto Adicionar(CreateGerenteDto gerenteDto)
        {
            var gerente = _mapper.Map<Gerente>(gerenteDto);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public List<ReadGerenteDto> Recuperar()
        {
            List<Gerente> gerentes = _context.Gerentes.ToList();

            if (gerentes != null)
            {
                return _mapper.Map<List<ReadGerenteDto>>(gerentes);
            }

            return null;
        }

        public ReadGerenteDto RecuperarPorId(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);

            if (gerente != null)
            {
                return _mapper.Map<ReadGerenteDto>(gerente);
            }

            return null;
        }

        public Result Deletar(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(x => x.Id == id);

            if (gerente == null)
            {
                return Result.Fail("Erro ao deletar Gerente");
            }

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();

            return Result.Ok();
        }

    }
}
