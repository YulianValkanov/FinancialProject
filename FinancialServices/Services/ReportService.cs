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
        private readonly IFormulasService formulasService;

        public ReportService(

            IRepository _repo,
            IFormulasService _formulasService)
        {

            repo = _repo;
            formulasService = _formulasService;
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

        public async Task <DetailsPnlViewModel> GetAnnualPnlAsync(long idEik)
        {
            string companyName = "";


            var company = await repo.AllReadonly<Company>()
               .FirstOrDefaultAsync(x => x.IdEik == idEik);

            if (company != null && company.CompanyName != null)
            {
                companyName = company.CompanyName;
            }

            var pnl = await repo.AllReadonly<PNL>()
                .Where(x => x.Eik == idEik)
                 .Select(c => new PnlViewModel()
                 {
                    CompanyName = c.CompanyName,
                    Eik=idEik,
                    Year=c.Year,
                     N15100 = formulasService.FormatNumbersAddSpace(c.N15100),//Приходи от продажби
                     N15110 = formulasService.FormatNumbersAddSpace( c.N15110),//Приходи от продукция
                    N15120 = formulasService.FormatNumbersAddSpace( c.N15120),//Приходи от стоки
                    N15130=formulasService.FormatNumbersAddSpace(c.N15130),//Приходи от услуги
                    N15200=formulasService.FormatNumbersAddSpace( c.N15200),//Увеличение на запасите от готова продукция
                    N15000=formulasService.FormatNumbersAddSpace( c.N15000),//Общо приходи
                    N16300=formulasService.FormatNumbersAddSpace( c.N16300),//Приходи от лихви и финансови приходи
                    N16000 = formulasService.FormatNumbersAddSpace(c.N14100),//Общо финансови приходи
                    N18000 =formulasService.FormatNumbersAddSpace( c.N18000),//Общо приходи
                    N19000 = formulasService.FormatNumbersAddSpace(c.N19000),//Загуба от обичайна дейност
                    N19100 = formulasService.FormatNumbersAddSpace(c.N19100),//Счетоводна загуба
                    N19200 = formulasService.FormatNumbersAddSpace(c.N19200),//Загуба

                     N10200 = formulasService.FormatNumbersAddSpace(c.N10200),//Външни услуги и материали
                     N10210 =formulasService.FormatNumbersAddSpace( c.N10210),//Суровини и материали
                    N10220 = formulasService.FormatNumbersAddSpace(c.N10220),//Външни услуги

                     N10300 = formulasService.FormatNumbersAddSpace(c.N10220),//Възнаграждения
                     N10310 = formulasService.FormatNumbersAddSpace(c.N10220),//Заплати
                     N10320 = formulasService.FormatNumbersAddSpace(c.N10220),//Осигуровки

                     N10400 = formulasService.FormatNumbersAddSpace(c.N10400),//Амортизации и обезценки

                     N10500 = formulasService.FormatNumbersAddSpace(c.N10500),//Други разходи
                     N10510 = formulasService.FormatNumbersAddSpace(c.N10510),//Балансова стойност на продадени активи
                     N10520 = formulasService.FormatNumbersAddSpace(c.N10520),//Провизии

                     N10100 = formulasService.FormatNumbersAddSpace(c.N10100),//Намаление на запасите от готова продукция

                     N11200 = formulasService.FormatNumbersAddSpace(c.N11200),//Разходи за лихви
                     N11000 = formulasService.FormatNumbersAddSpace(c.N11000),//Общо финансови разходи

                     N13000 = formulasService.FormatNumbersAddSpace(c.N13000),//Общо разходи
                     N10000 = formulasService.FormatNumbersAddSpace(c.N10000),//Общо оперативни разходи

                     N14000 = formulasService.FormatNumbersAddSpace(c.N14000),//Печалба от обичайна дейност
                     N14100 = formulasService.FormatNumbersAddSpace(c.N14100),//Счетоводна печалба
                     N14200 = formulasService.FormatNumbersAddSpace(c.N14200),//Данъци
                     N14300 = formulasService.FormatNumbersAddSpace(c.N14300),//Алтернативни Данъци
                     N14400 = formulasService.FormatNumbersAddSpace(c.N14400),//Печалба







                 })
                .ToListAsync();

            var model = new DetailsPnlViewModel()
            {
                IdEik = idEik,
                CompanyName = companyName,
                Reports = pnl
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
