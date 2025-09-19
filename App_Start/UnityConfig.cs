using LoanManagementSystem.Data;
using LoanManagementSystem.DBContext;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using LoanManagementSystem.Services;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace LoanManagementSystem.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();


            container.RegisterType<LoanDBContext>();


            container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            container.RegisterType<IBorrowerService, BorrowerService>();
            container.RegisterType<ILoanService, LoanService>();
            container.RegisterType<IRepaymentService, RepaymentService>();
            container.RegisterType<ITransactionService, TransactionService>();
            container.RegisterType<IContractService, ContractService>();
            container.RegisterType<IInterestRateService, InterestRateService>();

  
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}