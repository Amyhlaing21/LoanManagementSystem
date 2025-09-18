using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services
{
    public interface IBorrowerService
    {
        IEnumerable<Borrower> GetAllBorrowers();
        Borrower GetBorrowerById(int id);
        void CreateBorrower(Borrower borrower);
        void UpdateBorrower(Borrower borrower);
        void DeleteBorrower(int id);
    }
}
