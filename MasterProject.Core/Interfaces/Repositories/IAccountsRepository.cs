using MasterProject.Core.Dto;

namespace MasterProject.Core.Interfaces.Repositories
{
    public interface IAccountsRepository
    {
        bool CreateAccount(AccountDto account);
        bool CheckUserDataComplete(string id);
        bool AddAccountDetails(AccountDto account);
        int GetUserRole(string id);
        DataTablesObject<AccountDto> GetAccountList(SearchFilters searchFilter);
    }
}
