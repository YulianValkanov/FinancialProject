namespace FinancialServices.Contracts
{
    public interface IDatabaseService
    {

        //Task<IEnumerable<MovieViewModel>> GetAllAsync();

        //Task <string> GetAllAsync();

        Task ImportsEntities();

        Task ImportCompanies();

        Task ImportPersons();

        Task ImportManagers();

        Task ImportOwnerPersons();


        Task ImportOwnerCompany();

        Task ImportKid();

        Task ImportReports();

        Task ImportReportsMaping();

        Task ImportOpr(long IdEik, string CompanyName, int YearReport);

    }
}
