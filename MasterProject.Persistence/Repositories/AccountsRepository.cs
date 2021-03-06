﻿namespace MasterProject.Persistence.Repositories
{
    using Core;
    using Core.Dto;
    using Core.Interfaces.Repositories;
    using Core.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums = Core.Enums;
    using System.Linq.Dynamic;

    public class AccountsRepository : IAccountsRepository
    {
        private readonly IHospitalContext _context;
        private readonly IErrorLogsRepository _errorLogsRepository;

        public AccountsRepository(IHospitalContext context, IErrorLogsRepository errorLogsRepository)
        {
            _context = context;
            _errorLogsRepository = errorLogsRepository;
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
                _errorLogsRepository.LogError(ex);
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
                _errorLogsRepository.LogError(ex);
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
                _errorLogsRepository.LogError(ex);
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

        public DataTablesObject<AccountDto> GetAccountList(SearchFilters searchFilter)
        {
            var accountList = new List<AccountDto>();

            var doctors = (from doctor in _context.Doctors
                           select new AccountDto
                           {
                               RoleName = "Doktor",
                               Name = doctor.FirstName,
                               Surname = doctor.Surname,
                               WardName = doctor.Ward.Name,
                               PhoneNumber = doctor.PhoneNumber,
                               IsActive = doctor.User.IsActive,
                               UserId = doctor.User.Id
                           }).ToList();

            var nurses = (from nurse in _context.Nurses
                          select new AccountDto
                          {
                              RoleName = "Pielęgniarka",
                              Name = nurse.FirstName,
                              Surname = nurse.Surname,
                              WardName = nurse.Ward.Name,
                              PhoneNumber = nurse.PhoneNumber,
                              IsActive = nurse.User.IsActive,
                              UserId = nurse.User.Id
                          }).ToList();

            accountList.AddRange(doctors);
            accountList.AddRange(nurses);

            var count = 1;
            accountList.ForEach(x => x.Id = count++);

            var outputList = accountList.OrderBy(searchFilter.OrderBy).Skip(searchFilter.DisplayStart)
                .Take(searchFilter.DisplayLength).ToList();

            var postRequests = new DataTablesObject<AccountDto>();
            postRequests.iTotalRecords = postRequests.iTotalDisplayRecords = accountList.Count;
            postRequests.aaData = outputList;

            return postRequests;
        }

        public bool EditAccount(bool isActive, string id)
        {
            try
            {
                var context = new HospitalContext();
                var userManager = new UserManager<Users>(new UserStore<Users>(context));

                var user = userManager.FindById(id);

                user.IsActive = isActive;
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _errorLogsRepository.LogError(ex);
                return false;
            }
        }

        public string GetUserName(string userId)
        {
            try
            {
                var context = new HospitalContext();
                var userManager = new UserManager<Users>(new UserStore<Users>(context));

                var user = userManager.FindById(userId);

                return $"{user.FirstName} {user.LastName}";
            }
            catch (Exception ex)
            {
                _errorLogsRepository.LogError(ex);
                return string.Empty;
            }
        }
    }
}
