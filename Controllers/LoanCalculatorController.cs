using LoanManagementSystem.DBContext;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using LoanManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanManagementSystem.Controllers
{
    public class LoanCalculatorController : Controller
    {
        private readonly ILoanCalculatorService _calculator;

        public LoanCalculatorController()
        {
            var context = new LoanDBContext();
            _calculator = new LoanCalculatorService(new GenericRepository<Loan>(context));
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(decimal principal, decimal annualRate, int months)
        {
            var result = _calculator.MonthlyPayment(principal, annualRate, months);
            ViewBag.MonthlyPayment = result;
            return View("Index");
        }
    }
}