using System;
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class Repayment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Loan is required")]
        public int LoanId { get; set; }

        [Required(ErrorMessage = "Payment Date is required")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Amount Paid is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount Paid must be greater than zero")]
        public decimal AmountPaid { get; set; }

        [Required]
        public decimal RemainingBalance { get; set; }

        [Required(ErrorMessage = "Payment Term is required")]
        [Range(1, 360, ErrorMessage = "Payment term must be between 1 and 360 months")]
        public int PaymentTermMonths { get; set; }

        public virtual Loan Loan { get; set; }
    }
}