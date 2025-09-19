using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services
{
    public interface IRepaymentService
    {
        IEnumerable<Repayment> GetAllRepayments();
        Repayment GetRepaymentById(int id);
        void CreateRepayment(Repayment repayment);
        void UpdateRepayment(Repayment repayment);
        void DeleteRepayment(int id);

        //decimal GetTotalPaidForLoan(int loanId);
    }
}


