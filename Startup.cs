using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LoanManagementSystem.Startup))]

namespace LoanManagementSystem
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            SeedRolesAndAdmin();
        }

        private void SeedRolesAndAdmin()
        {
            using (var context = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                if (!roleManager.RoleExists("Admin")) roleManager.Create(new IdentityRole("Admin"));
                if (!roleManager.RoleExists("LoanOfficer")) roleManager.Create(new IdentityRole("LoanOfficer"));

                var adminEmail = System.Configuration.ConfigurationManager.AppSettings["AdminEmail"];
                var adminPassword = System.Configuration.ConfigurationManager.AppSettings["AdminPassword"];

                if (userManager.FindByName(adminEmail) == null)
                {
                    var adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail };
                    userManager.Create(adminUser, adminPassword);
                    userManager.AddToRole(adminUser.Id, "Admin");
                }

                var officerEmail = System.Configuration.ConfigurationManager.AppSettings["DefaultOfficerEmail"];
                var officerPassword = System.Configuration.ConfigurationManager.AppSettings["DefaultOfficerPassword"];

                if (!string.IsNullOrEmpty(officerEmail) && userManager.FindByName(officerEmail) == null)
                {
                    var officerUser = new ApplicationUser { UserName = officerEmail, Email = officerEmail };
                    userManager.Create(officerUser, officerPassword);
                    userManager.AddToRole(officerUser.Id, "LoanOfficer");
                }
            }
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
           
        }
    }
}