using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string ImagePath { get; set; } = String.Empty;
        public int RegionId { get; set; }
        public int TipoId { get; set; }
        public int Tipo2Id { get; set; }
        public PokemonRegion Region { get; set; }
        public PokemonTipo Tipo { get; set; }
    }
}
