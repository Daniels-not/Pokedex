using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SavePokemon
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pokemon name is required.")]
        [MaxLength(255)]
        public string Name { get; set; } = String.Empty;
        [Required(ErrorMessage = "Pokemon image is required.")]
        [Url]
        public string ImagePath { get; set; } = String.Empty;
        [Required(ErrorMessage = "Pokemon region is required.")]
        public int Region { get; set; }
        [Required(ErrorMessage = "Pokemon type is required.")]
        public int Tipo1 { get; set; }
        public int Tipo2 { get; set; } = 0;
    }
}
