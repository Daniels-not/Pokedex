using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class PokemonsModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string ImagePath { get; set; } = String.Empty;
        public string Region { get; set; } 
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }
        public int RegionId { get; set; }
    }
}
