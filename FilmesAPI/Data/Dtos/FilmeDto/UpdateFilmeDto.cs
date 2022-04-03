using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateFilmeDto
    {
        //[Key]
        //[Required]
        //public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Titulo { get; set; }
        [Required]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "Máximo de caracteres.")]
        public string Gereno { get; set; }
        [Range(40, 160, ErrorMessage = "Duração passou dos limites!")]
        public int Duracao { get; set; }
        public int FaixaEtaria { get; set; }

    }
}
