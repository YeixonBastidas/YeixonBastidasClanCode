using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class BetRoulette
    {
        public int UserId { get; set; }
        public double BetMoney { get; set; }
        public string BetFor { get; set; }
        public bool IsGame { get; set; }
        public DateTime BetDate { get; set; }
        public int StartRouletteId { get; set; }
    }
}
