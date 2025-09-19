using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagementSystem.Services
{
    public class RepaymentService : IRepaymentService
    {
        private readonly IGenericRepository<Repayment> _repo;
        public RepaymentService(IGenericRepository<Repayment> repo) { _repo = repo; }

        public IEnumerable<Repayment> GetAllRepayments() => _repo.GetAll();

        public Repayment GetRepaymentById(int id) => _repo.GetById(id);

        public void CreateRepayment(Repayment repayment) => _repo.Add(repayment);

        public void UpdateRepayment(Repayment repayment) => _repo.Update(repayment);

        public void DeleteRepayment(int id) => _repo.Delete(id);
        //public decimal GetTotalPaidForLoan(int loanId)
        //{
        //    return _repo.GetAll().Where(r => r.LoanId == loanId).Sum(r => r.AmountPaid);
        //}
    }

}