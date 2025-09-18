using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace LoanManagementSystem.Services
{
    public class LoanService : ILoanService
    {
        private readonly IGenericRepository<Loan> _loanRepo;

        public LoanService(IGenericRepository<Loan> loanRepo)
        {
            _loanRepo = loanRepo;
        }

        public IEnumerable<Loan> GetAllLoans()
        {
            return _loanRepo.GetAll()
                            .Include(l => l.Borrower)
                            .Include(l => l.InterestRate)
                            .ToList();
        }


        public Loan GetLoanById(int id)
        {
            return _loanRepo.GetAll()
                            .Include(l => l.Borrower)
                            .Include(l => l.InterestRate)
                            .FirstOrDefault(l => l.Id == id);
        }

        public Loan GetLoanByBorrowerId(int id)
        {
            return _loanRepo.GetAll()
                            .Include(l => l.Borrower)
                            .Include(l => l.InterestRate)
                            .FirstOrDefault(l => l.BorrowerId == id);
        }

        public void CreateLoan(Loan loan)
        {
            _loanRepo.Add(loan);
        }

        public void UpdateLoan(Loan loan)
        {
            _loanRepo.Update(loan);
        }

        public void DeleteLoan(int id)
        {
            _loanRepo.Delete(id);
        }
    }
}