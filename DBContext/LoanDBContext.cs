using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoanManagementSystem.DBContext
{
    public class LoanDBContext : DbContext
    {
        public LoanDBContext() : base("DefaultConnection") { }

        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Repayment> Repayments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<InterestRate> InterestRates { get; set; }
    }
}