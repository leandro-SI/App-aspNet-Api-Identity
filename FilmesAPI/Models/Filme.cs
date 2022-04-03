using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Titulo { get; set; }
        [Required]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "Máximo de caracteres.")]
        public string Gereno { get; set; }
        [Range(40, 160, ErrorMessage = "Duração passou dos limites!")]
        public int Duracao { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
        public int FaixaEtaria { get; set; }
    }
}
