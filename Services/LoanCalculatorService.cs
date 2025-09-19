using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanManagementSystem.Services
{
    public class LoanCalculatorService : ILoanCalculatorService
    {
        private readonly IGenericRepository<Loan> _loanRepo;

        public LoanCalculatorService(IGenericRepository<Loan> loanRepo)
        {
            _loanRepo = loanRepo;
        }
        public decimal MonthlyPayment(decimal principal, decimal annualRate, int months)
        {
            if (months <= 0) return 0;
            var monthlyRate = (double)(annualRate / 100m) / 12;
            var amount = (double)principal;
            var n = months;
            var payment = (decimal)((amount * monthlyRate) / (1 - Math.Pow(1 + monthlyRate, -n)));
            return Math.Round(payment, 2);
        }
    }
}