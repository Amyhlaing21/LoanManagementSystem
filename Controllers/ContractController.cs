using LoanManagementSystem.DBContext;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using LoanManagementSystem.Services;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanManagementSystem.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractService _contractService;
        private readonly ILoanService _loanService;

        public ContractController()
        {
            var context = new LoanDBContext();
            _loanService = new LoanService(new GenericRepository<Loan>(context));
            _contractService = new ContractService(new GenericRepository<Contract>(context));
        }

        public ActionResult Index() => View(_contractService.GetAllContracts().ToList());

        public ActionResult Create()
        {
            ViewBag.LoanId = new SelectList(_loanService.GetAllLoans(), "Id", "LoanType");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contract contract, HttpPostedFileBase ContractFile)
        {
            if (ContractFile != null && ContractFile.ContentLength > 0)
            {
                string fileName = Path.GetFileName(ContractFile.FileName);
                string path = Path.Combine(Server.MapPath("~/Uploads/Contracts"), fileName);
                ContractFile.SaveAs(path);
                contract.FilePath = "/Uploads/Contracts/" + fileName;
                contract.ContractFileName = fileName;
                contract.SigningDate = contract.SigningDate;
               _contractService.CreateContract(contract);
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Download(int id)
        {
            var contract = _contractService.GetContractById(id);
            if (contract == null) return HttpNotFound();


            var folder = @"D:\LoanManagementSystemLatest\LoanManagementSystem\Uploads\Contracts";
            var fullPath = Path.Combine(folder, contract.ContractFileName);

            if (!System.IO.File.Exists(fullPath))
            {
                return HttpNotFound("File not found");
            }

            var contentType = MimeMapping.GetMimeMapping(fullPath); 
            var fileBytes = System.IO.File.ReadAllBytes(fullPath);

            return File(fileBytes, contentType, contract.ContractFileName);
        }
        public ActionResult Delete(int id)
        {
            var contract = _contractService.GetContractById(id);
            if (contract == null) return HttpNotFound();

            string fullPath = Server.MapPath(contract.FilePath);
            if (System.IO.File.Exists(fullPath)) System.IO.File.Delete(fullPath);

            _contractService.DeleteContract(id);
            return RedirectToAction("Index");
        }
    }
}