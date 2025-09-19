using System.Web.Mvc;

namespace LoanManagementSystem.Controllers
{
    [Authorize] // Only authenticated users can see the dashboard
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // You can pass some dashboard data here in the future
            ViewBag.WelcomeMessage = "Welcome to the Loan Management System!";
            return View();
        }
    }
}