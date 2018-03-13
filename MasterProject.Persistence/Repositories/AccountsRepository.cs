namespace MasterProject.Persistence.Repositories
{
    using Core.Dto;
    using Core.Enums;
    using Core.Interfaces.Repositories;
    using Core.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    public class AccountsRepository : IAccountsRepository
    {
        public bool CreateAccount(AccountDto account)
        {
            try
            {
                var context = new HospitalContext();
                var userManager = new UserManager<Users>(new UserStore<Users>(context));

                var user = new Users
                {
                    UserName = account.UserName,
                    Email = account.Email,
                    FirstName = account.Name,
                    LastName = account.Surname
                };
                var chkUser = userManager.Create(user, account.Password);

                var result = new IdentityResult();
                if (chkUser.Succeeded)
                {
                    result = userManager.AddToRole(user.Id, ((Roles) account.Role).ToString());
                }

                return result.Succeeded;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
