using System.Collections.Generic;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Services
{
    public interface IInterestRateService
    {
        IEnumerable<InterestRate> GetAllRates();
        InterestRate GetRateById(int id);
        void CreateRate(InterestRate rate);
        void UpdateRate(InterestRate rate);
        void DeleteRate(int id);
    }
}