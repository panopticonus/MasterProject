namespace MasterProject.Manager.Users
{
    using DAL;
    using DAL.Model;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    public class AppUsersManager
    {
        public static Func<UserManager<AppUser>> UserManagerFactory { get; private set; }

        public void Configure()
        {
            // configure the user manager
            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<AppUser>(
                    new UserStore<AppUser>(new HospitalContext()));
                // allow alphanumeric characters in username
                usermanager.UserValidator = new UserValidator<AppUser>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                return usermanager;
            };
        }
    }
}
