using System.ComponentModel.DataAnnotations;

namespace PartyPlannerV6.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public string? EventName { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public float Costs { get; set; }

        [Required]
        public int AvailableParticipants { get; set; }

        [Required]
        public int CurrentParticipants { get; set; }

        public Category? Category { get; set; } // Navigation property to the Category entity

        public List<Participant> Participants { get; set; } = new List<Participant>();

        public List<Cashier> Cashiers { get; set; } = new List<Cashier>();

        public void ReduceAvailableSpots()
        {
            if (CurrentParticipants < AvailableParticipants)
            {
                AvailableParticipants--;
                CurrentParticipants++;
            }
            else
            {
                throw new InvalidOperationException("Er zijn geen beschikbare plaatsen meer voor dit evenement.");
            }
        }
    }
}
