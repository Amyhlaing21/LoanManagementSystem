using LoanManagementSystem.DBContext;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using LoanManagementSystem.Services;
using System;
using System.Net;
using System.Web.Mvc;

namespace LoanManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InterestRateController : Controller
    {
        private readonly IInterestRateService _interestRateService;

        public InterestRateController()
        {
            var context = new DBContext.LoanDBContext();
            _interestRateService = new InterestRateService(new Repository.GenericRepository<InterestRate>(context));
        }


        public ActionResult Index()
        {
            var rates = _interestRateService.GetAllRates();
            return View(rates);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InterestRate rate)
        {
            if (ModelState.IsValid)
            {
                _interestRateService.CreateRate(rate);
                return RedirectToAction("Index");
            }
            return View(rate);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var rate = _interestRateService.GetRateById(id.Value);
            if (rate == null) return HttpNotFound();

            return View(rate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InterestRate rate)
        {
            if (ModelState.IsValid)
            {
                _interestRateService.UpdateRate(rate);
                return RedirectToAction("Index");
            }
            return View(rate);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var rate = _interestRateService.GetRateById(id.Value);
            if (rate == null) return HttpNotFound();

            return View(rate);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _interestRateService.DeleteRate(id);
            return RedirectToAction("Index");
        }
    }
}