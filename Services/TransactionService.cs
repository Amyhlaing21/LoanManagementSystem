using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using System.Collections.Generic;

namespace LoanManagementSystem.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IGenericRepository<Transaction> _repo;

        public TransactionService(IGenericRepository<Transaction> repo)
        {
            _repo = repo;
        }

        public IEnumerable<Transaction> GetAllTransactions() => _repo.GetAll();
        public Transaction GetTransactionById(int id) => _repo.GetById(id);
        public void CreateTransaction(Transaction transaction) => _repo.Add(transaction);
        public void UpdateTransaction(Transaction transaction) => _repo.Update(transaction);
        public void DeleteTransaction(int id) => _repo.Delete(id);
    }
}