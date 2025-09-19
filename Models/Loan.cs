using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystem.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BorrowerId { get; set; }
        [ForeignKey("BorrowerId")]
        public virtual Borrower Borrower { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string LoanType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DateRange("StartDate", ErrorMessage = "End Date must be greater than or equal to Start Date.")]
        public DateTime EndDate { get; set; }
        [Required]
        public int? InterestRateId { get; set; }
        [ForeignKey("InterestRateId")]
        public virtual InterestRate InterestRate { get; set; }


        [NotMapped]
        public decimal TotalAmountWithInterest => InterestRate != null ? Amount + (Amount * InterestRate.RatePercent / 100) : Amount;
    }
}