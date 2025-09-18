using LoanManagementSystem.Models;
using LoanManagementSystem.Services;
using Microsoft.Azure.Amqp.Framing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanManagementSystem.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly IBorrowerService _borrowerService;
        private readonly IInterestRateService _interestRateService;

        public LoanController()
        {
            var context = new DBContext.LoanDBContext();
            _loanService = new LoanService(new Repository.GenericRepository<Loan>(context));
            _borrowerService = new BorrowerService(new Repository.GenericRepository<Borrower>(context));
            _interestRateService = new InterestRateService(new Repository.GenericRepository<InterestRate>(context));
        }

        public ActionResult Index()
        {
            var loans = _loanService.GetAllLoans();
            return View(loans);
        }

        public ActionResult Create()
        {
            ViewBag.Borrowers = new SelectList(_borrowerService.GetAllBorrowers(), "Id", "FullName");
            ViewBag.InterestRates = _interestRateService.GetAllRates();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Loan loan)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Borrowers = new SelectList(_borrowerService.GetAllBorrowers(), "Id", "FullName");
                return View(loan);
            }

            var loanInfo = _loanService.GetLoanByBorrowerId(loan.BorrowerId);
            if(loanInfo == null)
            {
                _loanService.CreateLoan(loan);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "A loan for this borrower already exists.");
                ViewBag.Borrowers = new SelectList(_borrowerService.GetAllBorrowers(), "Id", "FullName");
                ViewBag.InterestRates = _interestRateService.GetAllRates();
                return View(loan);
            }
           
        }

        public ActionResult Details(int id)
        {
            var loan = _loanService.GetLoanById(id);
            if (loan == null) return HttpNotFound();
            return View(loan);
        }
    }
}