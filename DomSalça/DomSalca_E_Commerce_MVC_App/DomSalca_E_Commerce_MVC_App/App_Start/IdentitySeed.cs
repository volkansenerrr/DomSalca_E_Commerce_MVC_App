using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using DomSalca_E_Commerce_MVC_App.Models; // ApplicationUser ve ApplicationDbContext

namespace DomSalca_E_Commerce_MVC_App.App_Start
{
    public class IdentitySeed
    {
        public static void SeedAdminUser(IAppBuilder app)
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Rol yoksa oluştur
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            // Admin kullanıcı bilgileri
            string adminEmail = "admin@domsalca.com";
            string adminPassword = "Admin@123";

            var adminUser = userManager.FindByEmail(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = userManager.Create(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    userManager.AddToRole(adminUser.Id, "Admin");
                }

            }
        }
    }
}
