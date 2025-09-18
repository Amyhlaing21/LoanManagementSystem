using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class Borrower
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Identification Number is required")]
        [StringLength(50)]
        public string IdentificationNumber { get; set; }

        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}