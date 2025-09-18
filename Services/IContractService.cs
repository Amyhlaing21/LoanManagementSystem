using System.Collections.Generic;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Services
{
    public interface IContractService
    {
        IEnumerable<Contract> GetAllContracts();
        Contract GetContractById(int id);
        void CreateContract(Contract contract);
        void UpdateContract(Contract contract);
        void DeleteContract(int id);
    }
}