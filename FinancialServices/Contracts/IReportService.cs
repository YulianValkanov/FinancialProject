using FinancialServices.Data.Models;
using FinancialServices.Models.Companies;
using FinancialServices.Models.Reports;

namespace FinancialServices.Contracts
{
    public interface IReportService
    {

        Task <DetailsReportViewModel> GetAllAsync(long idEik);

        Task AddReportAsync(long idEik, AddReportViewModel model);

        Task<bool> isReportExist(long idEik, int year);

        Task DeleteAsync(long idEik, int year);

        Task<ReportData> GetReportAsync(long idEik, int year);

        Task EditReportAsync(long idEik, ReportViewModel model);
    }
}
