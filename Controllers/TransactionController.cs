using LoanManagementSystem.DBContext;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using LoanManagementSystem.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LoanManagementSystem.Controllers
{
    [Authorize(Roles = "Admin,LoanOfficer")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ILoanService _loanService;

        public TransactionController()
        {
            var context = new LoanDBContext();
            _loanService = new LoanService(new GenericRepository<Loan>(context));
            _transactionService = new TransactionService(new GenericRepository<Transaction>(context));
        }


        public ActionResult Index()
        {
            var transactions = _transactionService.GetAllTransactions().ToList();
            return View(transactions);
        }

        public ActionResult Create()
        {
            ViewBag.LoanId = new SelectList(_loanService.GetAllLoans(), "Id", "Borrower.FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.LoanId = new SelectList(_loanService.GetAllLoans(), "Id", "Borrower.FullName", transaction.LoanId);
                return View(transaction);
            }

            _transactionService.CreateTransaction(transaction);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            if (transaction == null) return HttpNotFound();

            ViewBag.LoanId = new SelectList(_loanService.GetAllLoans(), "Id", "Borrower.FullName", transaction.LoanId);
            return View(transaction);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.LoanId = new SelectList(_loanService.GetAllLoans(), "Id", "LoanType", transaction.LoanId);
                return View(transaction);
            }

            _transactionService.UpdateTransaction(transaction);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            if (transaction == null) return HttpNotFound();

            _transactionService.DeleteTransaction(id);
            return RedirectToAction("Index");
        }
    }
}