using System.ComponentModel.DataAnnotations;

namespace PartyPlannerV6.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }

        [Required]
        public string? Name { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
