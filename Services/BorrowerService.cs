using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanManagementSystem.Services
{
    public class BorrowerService : IBorrowerService
    {
        private readonly IGenericRepository<Borrower> _borrowerRepo;

        public BorrowerService(IGenericRepository<Borrower> borrowerRepo)
        {
            _borrowerRepo = borrowerRepo;
        }

        public IEnumerable<Borrower> GetAllBorrowers()
        {
            return _borrowerRepo.GetAll();
        }

        public Borrower GetBorrowerById(int id)
        {
            return _borrowerRepo.GetById(id);
        }

        public void CreateBorrower(Borrower borrower)
        {
            _borrowerRepo.Add(borrower);
        }

        public void UpdateBorrower(Borrower borrower)
        {
            _borrowerRepo.Update(borrower);
        }

        public void DeleteBorrower(int id)
        {
            _borrowerRepo.Delete(id);
        }
    }
}