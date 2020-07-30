using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class BetDTO
    {
        public int UserId { get; set; }
        public int BetMoney { get; set; }
        public string BetFor { get; set; }
        public int RouletteId { get; set; }
    }
}
