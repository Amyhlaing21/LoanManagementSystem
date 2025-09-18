using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using System.Collections.Generic;

namespace LoanManagementSystem.Services
{
    public class ContractService : IContractService
    {
        private readonly IGenericRepository<Contract> _repo;

        public ContractService(IGenericRepository<Contract> repo)
        {
            _repo = repo;
        }

        public IEnumerable<Contract> GetAllContracts() => _repo.GetAll();
        public Contract GetContractById(int id) => _repo.GetById(id);
        public void CreateContract(Contract contract) => _repo.Add(contract);
        public void UpdateContract(Contract contract) => _repo.Update(contract);
        public void DeleteContract(int id) => _repo.Delete(id);
    }
}