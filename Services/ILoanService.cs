using Antlr.Runtime.Tree;
using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services
{
    public interface ILoanService
    {
        IEnumerable<Loan> GetAllLoans();
        Loan GetLoanById(int id);
        void CreateLoan(Loan loan);
        void UpdateLoan(Loan loan);
        void DeleteLoan(int id);
        Loan GetLoanByBorrowerId(int id);
    }
}
