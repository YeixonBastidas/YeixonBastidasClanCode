using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public double Money { get; set; }
        public bool Status { get; set; }
    }
}
