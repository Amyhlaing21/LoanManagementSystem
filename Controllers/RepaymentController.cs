using LoanManagementSystem.DBContext;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using LoanManagementSystem.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LoanManagementSystem.Controllers
{
    public class RepaymentController : Controller
    {
        private readonly IRepaymentService _repaymentService;
        private readonly ILoanService _loanService;

        public RepaymentController()
        {
            var context = new LoanDBContext();
            _loanService = new LoanService(new GenericRepository<Loan>(context));
            _repaymentService = new RepaymentService(new GenericRepository<Repayment>(context));
        }

        public ActionResult Index()
        {
            var repayments = _repaymentService.GetAllRepayments().ToList();
            return View(repayments);
        }

        public ActionResult Create()
        {
            ViewBag.LoanId = new SelectList(_loanService.GetAllLoans(), "Id", "LoanType");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Repayment repayment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.LoanId = new SelectList(_loanService.GetAllLoans(), "Id", "LoanType", repayment.LoanId);
                return View(repayment);
            }

            var loan = _loanService.GetLoanById(repayment.LoanId);
            if (loan != null)
            {
                repayment.RemainingBalance = (loan.Amount + (loan.Amount * loan.InterestRate.RatePercent / 100)) - repayment.AmountPaid;
                _repaymentService.CreateRepayment(repayment);

                loan.Amount = repayment.RemainingBalance;
                _loanService.UpdateLoan(loan);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var repayment = _repaymentService.GetRepaymentById(id);
            if (repayment == null) return HttpNotFound();

            ViewBag.LoanId = new SelectList(_loanService.GetAllLoans(), "Id", "LoanType", repayment.LoanId);
            return View(repayment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Repayment repayment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.LoanId = new SelectList(_loanService.GetAllLoans(), "Id", "LoanType", repayment.LoanId);
                return View(repayment);
            }

            var loan = _loanService.GetLoanById(repayment.LoanId);
            if (loan != null)
            {
                repayment.RemainingBalance = loan.Amount - repayment.AmountPaid;
                _repaymentService.UpdateRepayment(repayment);

                loan.Amount = repayment.RemainingBalance;
                _loanService.UpdateLoan(loan);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var repayment = _repaymentService.GetRepaymentById(id);
            if (repayment == null) return HttpNotFound();

            _repaymentService.DeleteRepayment(id);
            return RedirectToAction("Index");
        }
    }
}