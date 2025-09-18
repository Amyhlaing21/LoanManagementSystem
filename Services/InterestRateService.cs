using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using System.Collections.Generic;

namespace LoanManagementSystem.Services
{
    public class InterestRateService : IInterestRateService
    {
        private readonly IGenericRepository<InterestRate> _repo;

        public InterestRateService(IGenericRepository<InterestRate> repo)
        {
            _repo = repo;
        }

        public IEnumerable<InterestRate> GetAllRates() => _repo.GetAll();
        public InterestRate GetRateById(int id) => _repo.GetById(id);
        public void CreateRate(InterestRate rate) => _repo.Add(rate);
        public void UpdateRate(InterestRate rate) => _repo.Update(rate);
        public void DeleteRate(int id) => _repo.Delete(id);
    }
}