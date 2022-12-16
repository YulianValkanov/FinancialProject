using FinancialServices.Contracts;
using FinancialServices.Data.Common;
using FinancialServices.Data.Models;
using FinancialServices.Models.Persons;
using FinancialServices.Models.Reports;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Theatre.Data.Models;

namespace FinancialServices.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository repo;

        public ReportService(

            IRepository _repo)
        {

            repo = _repo;
        }

        public async Task AddReportAsync(long idEik, AddReportViewModel model)
        {

            var ReportData = new ReportData()
            {
                IdEik = idEik,
                YearReport = model.YearReport,
                AnnualTurnover = model.AnnualTurnover,
                Assets = model.Assets,
                CountOfEmployees = model.CountOfEmployees
            };


            await repo.AddAsync(ReportData);

            await repo.SaveChangesAsync();
        }

        public async Task<DetailsReportViewModel> GetAllAsync(long idEik)
        {
            string companyName = "";


            var company = await repo.AllReadonly<Company>()
               .FirstOrDefaultAsync(x => x.IdEik == idEik);

            if (company != null && company.CompanyName != null)
            {
                companyName = company.CompanyName;
            }

            var reports = await repo.AllReadonly<ReportData>()
                .Where(x => x.IdEik == idEik)
                 .Select(c => new ReportViewModel()
                 {
                     ReportId = c.ReportId,
                     IdEik = c.IdEik,
                     YearReport = c.YearReport,
                     Assets = c.Assets,
                     AnnualTurnover = c.AnnualTurnover,
                     CountOfEmployees = c.CountOfEmployees

                 })
                 .OrderBy(x=>x.YearReport)
                .ToListAsync();

            var model = new DetailsReportViewModel()
            {
                IdEik = idEik,
                CompanyName = companyName,
                Reports = reports
            };

            return model;
        }

        public async Task<bool> isReportExist(long idEik, int year)
        {
            var report = await repo.AllReadonly<ReportData>()
                .FirstOrDefaultAsync(r => r.IdEik == idEik && r.YearReport == year);

            if (report == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public async Task DeleteAsync(long idEik, int year)
        {
            var report = await repo.All<ReportData>()
                .Where(x => x.IdEik == idEik && x.YearReport == year)
               .FirstOrDefaultAsync();

            if (report != null)
            {
                await repo.DeleteAsync<ReportData>(report.ReportId);

                await repo.SaveChangesAsync();
            }


        }

        public async Task<ReportData> GetReportAsync(long idEik, int year)
        {

            var report = await repo.All<ReportData>()
                .FirstOrDefaultAsync(x => x.IdEik == idEik && x.YearReport == year);


            return report;
        }

        public async Task EditReportAsync(long idEik, ReportViewModel model)
        {
            var report = await GetReportAsync(idEik, model.YearReport);


            report.Assets = model.Assets;
            report.AnnualTurnover = model.AnnualTurnover;
            report.CountOfEmployees = model.CountOfEmployees;


            await repo.SaveChangesAsync();

        }
    }
}
