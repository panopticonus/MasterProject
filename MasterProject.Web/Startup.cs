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