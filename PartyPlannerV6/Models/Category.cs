using System.ComponentModel.DataAnnotations;

namespace PartyPlannerV6.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public ICollection<Event>? Events { get; set; } // Navigation property to the Event entity
    }
}
