using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SavePokemonRegion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pokemon type name is require.")]
        [MaxLength(255)]
        public string NombreRegion { get; set; } = String.Empty;

    }
}
