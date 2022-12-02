using FinancialServices.Models;
using FinancialServices.Models.Persons;

namespace FinancialServices.Contracts
{
    public interface IOwnerPersonService
    {

        Task AddOwnerAsync(long idEik, AddOwnerPersonViewModel model);

        Task DeleteAsync(long idEik, long idEgn);

    }
}
