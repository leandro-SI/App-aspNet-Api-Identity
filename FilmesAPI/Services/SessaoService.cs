using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.SessaoDto;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private readonly AppDbContext _context = null;
        private readonly IMapper _mapper = null;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto Adicionar(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public List<ReadSessaoDto> Recuperar()
        {
            List<Sessao> sessoes = _context.Sessoes.ToList();

            if (sessoes != null)
            {
                return _mapper.Map<List<ReadSessaoDto>>(sessoes);
            }

            return null;
        }

        public ReadSessaoDto RecuperarPorId(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(x => x.Id == id);

            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

                return sessaoDto;
            }

            return null;
        }

        public Result Deletar(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(x => x.Id == id);

            var aux = sessao;

            if (sessao == null)
                return Result.Fail("Erro ao deletar sessao");

            _context.Sessoes.Remove(sessao);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
