using Microsoft.Owin;

[assembly: OwinStartup(typeof(MasterProject.Web.Startup))]

namespace MasterProject.Web
{
    using Core.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Owin;
    using Persistence;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoleAndUsers();
        }

        private static void CreateRoleAndUsers()
        {
            var context = new HospitalContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<Users>(new UserStore<Users>(context));

            // In Startup creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  
                var user = new Users
                {
                    UserName = "Admin",
                    Email = "kamilan226@student.polsl.pl",
                    FirstName = "Kamil",
                    LastName = "Lang"
                };
                var chkUser = userManager.Create(user, "password123$");

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Admin");
                }
            }

            // creating Doctor role    
            if (!roleManager.RoleExists("Doctor"))
            {
                var role = new IdentityRole
                {
                    Name = "Doctor"
                };
                roleManager.Create(role);
            }

            // creating Nurse role    
            if (!roleManager.RoleExists("Nurse"))
            {
                var role = new IdentityRole
                {
                    Name = "Nurse"
                };
                roleManager.Create(role);
            }
        }

        private static void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new HospitalContext());
            app.CreatePerOwinContext<UserStore<Users>>(
                (opt, cont) => new UserStore<Users>(cont.Get<HospitalContext>()));
            app.CreatePerOwinContext<UserManager<Users>>(
                (opt, cont) =>
                {
                    var usermanager = new UserManager<Users>(cont.Get<UserStore<Users>>());

                    usermanager.UserValidator = new UserValidator<Users>(usermanager)
                    {
                        RequireUniqueEmail = true
                    };

                    return usermanager;
                });
            app.CreatePerOwinContext<SignInManager<Users, string>>(
                (opt, cont) => new SignInManager<Users, string>(cont.Get<UserManager<Users>>(),
                    cont.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}