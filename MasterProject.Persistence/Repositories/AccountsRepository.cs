namespace MasterProject.Persistence.Repositories
{
    using Core;
    using Core.Dto;
    using Core.Interfaces.Repositories;
    using Core.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Linq;
    using Enums = Core.Enums;

    public class AccountsRepository : IAccountsRepository
    {
        private readonly IHospitalContext _context;

        public AccountsRepository(IHospitalContext context)
        {
            _context = context;
        }

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
            try
            {
                var address = new Addresses
                {
                    BuildingNumber = account.BuildingNumber,
                    City = account.City,
                    CountryId = account.CountryId,
                    FlatNumber = account.FlatNumber,
                    Street = account.Street,
                    ZipCode = account.ZipCode
                };

                _context.Addresses.Add(address);
                _context.SaveChanges();

                var context = new HospitalContext();
                var userManager = new UserManager<Users>(new UserStore<Users>(context));

                var user = userManager.FindById(account.UserId);

                if (account.RoleId == (int)Enums.Roles.Doctor)
                {
                    var doctor = new Doctors
                    {
                        AddressId = address.Id,
                        DateOfBirth = account.DateOfBirth,
                        Degree = account.Degree,
                        DegreeOfSpecialty = account.DegreeOfSpecialty,
                        FirstName = user.FirstName,
                        Surname = user.LastName,
                        PhoneNumber = account.PhoneNumber,
                        Pwz = account.Pwz,
                        SpecialtyId = account.SpecialtyId,
                        UserId = user.Id,
                        WardId = account.WardId
                    };

                    _context.Doctors.Add(doctor);
                    _context.SaveChanges();
                }
                else
                {
                    var nurse = new Nurses
                    {
                        AddressId = address.Id,
                        DateOfBirth = account.DateOfBirth,
                        PhoneNumber = account.PhoneNumber,
                        FirstName = user.FirstName,
                        Pwz = account.Pwz,
                        Surname = user.LastName,
                        UserId = user.Id,
                        WardId = account.WardId
                    };

                    _context.Nurses.Add(nurse);
                    _context.SaveChanges();
                }

                user.IsDataComplete = true;
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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
                roleId = _context.ExpandedRoles.Single(x => x.Id == id).RoleId;
            }

            return roleId;
        }
    }
}
