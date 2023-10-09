using System.ComponentModel.DataAnnotations;

namespace PartyPlannerV6.Models
{
    public class Organizer
    {
        [Key]
        public int OrganizerId { get; set; }

        [Required]
        public string? Name { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();
    }
}
