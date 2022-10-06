using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SavePokemonType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pokemon type is required")]
        [MaxLength(100)]
        public string TipoPokemon { get; set; } = String.Empty;
    }
}
