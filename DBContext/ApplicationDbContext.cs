using LoanManagementSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LoanManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public static ApplicationDbContext Create() => new ApplicationDbContext();
    }
}