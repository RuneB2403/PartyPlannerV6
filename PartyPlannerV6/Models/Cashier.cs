using System.ComponentModel.DataAnnotations;

namespace PartyPlannerV6.Models
{
    public class Cashier
    {
        [Key]
        public int CashierId { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
