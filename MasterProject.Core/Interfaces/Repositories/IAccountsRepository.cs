using MasterProject.Core.Dto;

namespace MasterProject.Core.Interfaces.Repositories
{
    public interface IAccountsRepository
    {
        bool CreateAccount(AccountDto account);
    }
}
