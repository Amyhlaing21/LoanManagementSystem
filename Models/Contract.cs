using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystem.Models
{
    public class Contract
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Loan is required")]
        public int LoanId { get; set; }

        [Required(ErrorMessage = "Contract file name is required")]
        [StringLength(200)]
        public string ContractFileName { get; set; }

        [Required(ErrorMessage = "Signing Date is required")]
        [DataType(DataType.Date)]
        public DateTime SigningDate { get; set; }
        [NotMapped]
        public string FilePath { get; set; }

        public virtual Loan Loan { get; set; }
    }
}