using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Roulette
    {        
        public int RouletteId { get; set; }        
        public string RouletteName { get; set; }
        public bool RouletteStatus { get; set; }
    }
}
