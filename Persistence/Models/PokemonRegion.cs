using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    public class PokemonRegion
    {
        public int Id { get; set; }
        public string NombreRegion { get; set; } = String.Empty;
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
