using System.ComponentModel.DataAnnotations;

namespace TracerBreaker.Models
{
    public class Fruit
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
