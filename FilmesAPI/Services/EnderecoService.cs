using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.EnderecoDto;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        private readonly AppDbContext _context = null;
        private readonly IMapper _mapper = null;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto Adicionar(CreateEnderecoDto enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> Recuperar()
        {
            var enderecos = _context.Enderecos.ToList();

            if (enderecos != null)
            {
                return _mapper.Map<List<ReadEnderecoDto>>(enderecos);
            }

            return null;
        }

        public ReadEnderecoDto RecuperarPorId(int id)
        {
            var endereco = _context.Filmes.FirstOrDefault(e => e.Id == id);

            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

                return enderecoDto;
            }

            return null;
        }

        public Result Atualizar(int id, UpdateEnderecoDto enderecoDto)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

            if (endereco == null)
            {
                return Result.Fail("Erro ao atualizar endereco.");
            }

            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result Deletar(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

            if (endereco == null)
            {
                return Result.Fail("Erro ao deletar enderedo");
            }

            _context.Remove(endereco);
            _context.SaveChanges();

            return Result.Ok();
        }

    }
}
