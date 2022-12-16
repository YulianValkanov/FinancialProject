using FinancialServices.Data.Models;
using FinancialServices.Models.Companies;
using FinancialServices.Models.Credits;

namespace FinancialServices.Contracts
{
    public interface ICreditService
    {

        Task <DetailsCreditViewModel> GetAllAsync(long idEik);

        Task AddCreditAsync(long idEik, AddCreditViewModel model);

        Task<bool> isCreditExist(long idEik, int year);

        Task DeleteAsync(long idEik, int year);

        Task<Credit> GetCreditAsync(long idEik, int year);

        Task EditCreditAsync(long idEik, CreditViewModel model);
    }
}
