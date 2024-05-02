using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace ProjectFinal.Models
{
    public class Pokemon
    {
        public int PokemonId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Generation { get; set; }

        [Required]
        public string Region { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}

