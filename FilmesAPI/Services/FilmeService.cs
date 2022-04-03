using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private readonly AppDbContext _context = null;
        private readonly IMapper _mapper = null;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        

        public ReadFilmeDto Adicionar(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> Recuperar(int? faixaEtaria)
        {
            List<Filme> filmes = null;

            if (faixaEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(x => x.FaixaEtaria <= faixaEtaria).ToList();
            }

            if (filmes != null)
            {
                List<ReadFilmeDto> filmeDto = _mapper.Map<List<ReadFilmeDto>>(filmes).ToList();

                return filmeDto;
            }

            return null;
        }

        public ReadFilmeDto RecuperarPorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

                return filmeDto;
            }

            return null;
        }

        public Result Atualizar(int id, UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (filme == null)
            {
                return Result.Fail("Erro ao atualizar filme.");
            }

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result Deletar(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)
            {
                return Result.Fail("Erro ao deletar Filme.");
            }

            _context.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();
        }
            
    }

}
