using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class StartBetDTO
    {
        public int? StartRouletteId { get; set; }
        public int? UserId { get; set; }
        public int? RouletteId { get; set; }

        public double? UserMoney { get; set; }
    }
}
