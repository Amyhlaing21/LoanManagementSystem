using System.Collections.Generic;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Services
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int id);
        void CreateTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(int id);
    }
}