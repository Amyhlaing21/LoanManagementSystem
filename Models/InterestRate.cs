using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class InterestRate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Interest rate must be between 1% and 100%")]
        public decimal RatePercent { get; set; }

        public string Description { get; set; }
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}