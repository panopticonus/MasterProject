namespace MasterProject.Persistence.Repositories
{
    using Core.Dto;
    using Enums = Core.Enums;
    using Core.Interfaces.Repositories;
    using Core.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Linq;

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
                    result = userManager.AddToRole(user.Id, ((Enums.Roles)account.Role).ToString());
                }

                return result.Succeeded;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CheckUserDataComplete(string id)
        {
            try
            {
                var context = new HospitalContext();
                var userManager = new UserManager<Users>(new UserStore<Users>(context));

                var user = userManager.FindById(id);

                return user.IsDataComplete;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddAccountDetails(AccountDto account)
        {
            throw new NotImplementedException();
        }

        public int GetUserRole(string userId)
        {
            var context = new HospitalContext();
            var userManager = new UserManager<Users>(new UserStore<Users>(context));

            var user = userManager.FindById(userId);
            var identityUserRole = user.Roles.FirstOrDefault();

            var roleId = 0;
            if (identityUserRole != null)
            {
                var id = identityUserRole.RoleId;
                roleId = context.ExpandedRoles.Single(x => x.Id == id).RoleId;
            }

            return roleId;
        }
    }
}
