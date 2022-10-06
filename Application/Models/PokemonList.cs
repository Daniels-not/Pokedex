using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class PokemonList
    {
        public List<PokemonRegion> PokemonRegions { get; set; } = new();
        public List<PokemonTipo> PokemonTipo { get; set; } = new();
        public List<PokemonsModel> Pokemon { get; set; } = new();
    }
}
