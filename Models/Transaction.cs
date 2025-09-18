using System;
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Loan is required")]
        public int LoanId { get; set; }

        [Required(ErrorMessage = "Transaction Date is required")]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        [Required(ErrorMessage = "Transaction Type is required")]
        [StringLength(50)]
        public string TransactionType { get; set; } 

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public virtual Loan Loan { get; set; }
    }
}