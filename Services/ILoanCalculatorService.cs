using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services
{
    public interface ILoanCalculatorService
    {
        decimal MonthlyPayment(decimal principal, decimal annualInterestRate, int months);
    }
}
