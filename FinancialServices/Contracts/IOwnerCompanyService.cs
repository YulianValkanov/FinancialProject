using FinancialServices.Models;
using FinancialServices.Models.Persons;

namespace FinancialServices.Contracts
{
    public interface IOwnerCompanyService
    {

        Task AddOwnerAsync(long idEik, AddOwnerCompanyViewModel model);

        Task DeleteAsync(long idEik, long idOwnerEik);

    }
}
