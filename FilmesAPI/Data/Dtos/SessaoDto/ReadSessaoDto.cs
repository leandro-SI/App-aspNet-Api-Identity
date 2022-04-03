using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos.SessaoDto
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }

        public virtual Filme Filme { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}
