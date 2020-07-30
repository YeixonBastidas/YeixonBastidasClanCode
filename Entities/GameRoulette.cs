using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class GameRoulette
    {        
        public int GameRouletteId { get; set; }
        public User UserId { get; set; }
        public Roulette RouletteId { get; set; }
        public string Bet { get; set; }
        public double MoneyBet { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
