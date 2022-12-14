using Theatre.Data.Models;
using FinancialServices.Data.Models;
using FinancialServices.Services;
using FinancialServices.Models.Companies;

namespace FinancialServices.Contracts
{
    public interface ICompanyService
    {
        Task<IEnumerable<AllViewModel>> GetAllAsync();

        Task<Company> GetCompanyAsync(long idEik);

        Task<List< MapingOwnerCompany>> GetCompanyOwnersDataAsync(long idEik);

        Task <bool>  isCompanyExist(long idEik);

        Task<List<Company>> GetCompanyOwnersAsync(List<MapingOwnerCompany> ownersCompanydata);
    

        Task<List<Person>> GetManagersAsync(long idEik);

        Task DeleteAsync(long idEik);

        Task DeactivateAsync(long idEik);

        Task<CompanyInfoViewModel> CompanyDetailsById(long idEik);


        Task EditCompanyAsync(long idEik,AddCompaniesViewModel model);

       

        Task AddCompanyAsync(AddCompaniesViewModel model);



        Task<IEnumerable<AllViewModel>> AllFilter(
           string? eik = null,
           string? companyName = null,
              string? kid = null,
              string? group=null);
    }
}
