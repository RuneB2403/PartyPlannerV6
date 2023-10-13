using System.ComponentModel.DataAnnotations;

namespace PartyPlannerV6.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public bool Payed { get; set; }

        public Order()
        {
            DateTime = DateTime.Now;
        }
    }
}
