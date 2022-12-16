using FinancialServices.Models;
using FinancialServices.Models.Companies;
using FinancialServices.Models.Persons;
using Theatre.Data.Models;

namespace FinancialServices.Contracts
{
    public interface IPersonService
    {

        Task AddPersonAsync(AddPersonViewModel model);

        Task <bool> isPersonExist(long IdEgn);


        Task<IEnumerable<AllPersonViewModel>> AllFilter(
           string? egn = null,
           string? firstName = null,
              string?  lastName = null);

        Task<Person> GetPersonAsync(long idEgn);

        Task EditPersonAsync(long idEgn, AddPersonViewModel model);

        Task DeleteAsync(long idEgn);
    }
}
