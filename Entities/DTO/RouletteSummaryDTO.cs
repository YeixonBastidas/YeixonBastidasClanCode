using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Entities.DTO
{
    public class RouletteSummaryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AcomuladoBet  { get; set; }
    }
}
