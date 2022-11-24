using FinancialServices.Models;
using FinancialServices.Models.Persons;

namespace FinancialServices.Contracts
{
    public interface IManagerService
    {

        Task AddManagerAsync(long idEik, AddManagerViewModel model);

        Task DeleteAsync(long idEik, long idEgn);

    }
}
