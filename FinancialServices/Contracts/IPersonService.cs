using FinancialServices.Models;
using FinancialServices.Models.Persons;

namespace FinancialServices.Contracts
{
    public interface IPersonService
    {

        Task AddPersonAsync(AddPersonViewModel model);
    }
}
