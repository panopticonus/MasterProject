namespace MasterProject
{
    using Manager.Users;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // this is the same as before
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login")
            });

            new AppUsersManager().Configure();
        }
    }
}