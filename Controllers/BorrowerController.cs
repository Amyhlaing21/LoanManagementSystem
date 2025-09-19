using LoanManagementSystem.DBContext;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using LoanManagementSystem.Services;
using System;
using System.Web.Mvc;

namespace LoanManagementSystem.Controllers
{
    [Authorize(Roles = "Admin,LoanOfficer")]
    public class BorrowerController : Controller
    {
        private readonly IBorrowerService _borrowerService;

        public BorrowerController()
        {
            var context = new LoanDBContext();
            _borrowerService = new BorrowerService(new GenericRepository<Borrower>(context));
        }

        public ActionResult Index()
        {
            var borrowers = _borrowerService.GetAllBorrowers();
            return View(borrowers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Borrower borrower)
        {
            if (!ModelState.IsValid)
                return View(borrower);

            _borrowerService.CreateBorrower(borrower);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var borrower = _borrowerService.GetBorrowerById(id);
            if (borrower == null) return HttpNotFound();
            return View(borrower);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Borrower borrower)
        {
            if (!ModelState.IsValid)
                return View(borrower);

            var existing = _borrowerService.GetBorrowerById(borrower.Id);
            if (existing == null) return HttpNotFound();

            existing.FullName = borrower.FullName;
            existing.Email = borrower.Email;
            existing.Phone = borrower.Phone;
            existing.Address = borrower.Address;
            existing.IdentificationNumber = borrower.IdentificationNumber;

            _borrowerService.UpdateBorrower(existing);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var borrower = _borrowerService.GetBorrowerById(id);
            if (borrower == null) return HttpNotFound();

            _borrowerService.DeleteBorrower(id);
            return RedirectToAction("Index");
        }
    }
}