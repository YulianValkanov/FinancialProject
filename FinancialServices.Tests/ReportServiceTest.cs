using FinancialServices.Contracts;
using FinancialServices.Data.Common;
using FinancialServices.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialServices.Models.Persons;
using FinancialServices.Services;
using FinancialServices.Models.Reports;
using Theatre.Data.Models;
using FinancialServices.Data.Models;

namespace FinancialServices.Tests
{
    public class ReportServiceTest
    {
        [TestFixture]
        public class CompanyServiceTests
        {
            private IRepository repo;
            private IReportService reportService;
            private FinanceDbContext context;

            [SetUp]
            public void Setup()
            {

                var contextOptions = new DbContextOptionsBuilder<FinanceDbContext>()
                    .UseInMemoryDatabase("FinanceDB")
                    .Options;

                context = new FinanceDbContext(contextOptions);

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }


            [Test]
            public async Task TestGetReportAsync()
            {

                var repo = new Repository(context);
                reportService = new ReportService(repo);

                await repo.AddRangeAsync(new List<ReportData>()
            {
                new ReportData() { IdEik = 101, YearReport = 2017, AnnualTurnover=10000,  Assets=20000,CountOfEmployees=9},
               new ReportData() { IdEik = 102, YearReport = 2018, AnnualTurnover=10001,  Assets=20001,CountOfEmployees=10},
                new ReportData() { IdEik = 103, YearReport = 2019, AnnualTurnover=10002,  Assets=20002,CountOfEmployees=11},
            });

                await repo.SaveChangesAsync();
                var currentReport = await reportService.GetReportAsync(101, 2017);

                Assert.That(2017, Is.EqualTo(currentReport.YearReport));
                Assert.That(10000, Is.EqualTo(currentReport.AnnualTurnover));
                Assert.That(20000, Is.EqualTo(currentReport.Assets));
                Assert.That(9, Is.EqualTo(currentReport.CountOfEmployees));

                Assert.That(1, Is.EqualTo(currentReport.ReportId));

            }



            [Test]
            public async Task TestAddReportAsync()
            {

                var repo = new Repository(context);
                reportService = new ReportService(repo);

                var model = new AddReportViewModel()
                {
                    IdEik = 123,
                    YearReport = 2017,
                    Assets = 55000,
                    AnnualTurnover = 44000,
                    CountOfEmployees = 9
                };
                await reportService.AddReportAsync(123, model);


                var currentReport = await reportService.GetReportAsync(123, 2017);

                Assert.That(123, Is.EqualTo(currentReport.IdEik));
                Assert.That(2017, Is.EqualTo(currentReport.YearReport));
                Assert.That(55000, Is.EqualTo(currentReport.Assets));
                Assert.That(44000, Is.EqualTo(currentReport.AnnualTurnover));
                Assert.That(9, Is.EqualTo(currentReport.CountOfEmployees));

            }


            [Test]
            public async Task TestGetAllAsync()
            {

                var repo = new Repository(context);
                reportService = new ReportService(repo);

                await repo.AddRangeAsync(new List<ReportData>()
            {
                new ReportData() { IdEik = 101, YearReport = 2017, AnnualTurnover=10000,  Assets=20000,CountOfEmployees=9},
               new ReportData() { IdEik = 101, YearReport = 2018, AnnualTurnover=10001,  Assets=20001,CountOfEmployees=10},
                new ReportData() { IdEik = 103, YearReport = 2019, AnnualTurnover=10002,  Assets=20002,CountOfEmployees=11},
            });

                await repo.SaveChangesAsync();
                var currentReport = await reportService.GetAllAsync(101);


                Assert.That(currentReport.Reports.Count(), Is.EqualTo(2));
                Assert.That(currentReport.IdEik, Is.EqualTo(101));

            }



            [Test]
            public async Task TestisReportExist()
            {

                var repo = new Repository(context);
                reportService = new ReportService(repo);

                await repo.AddRangeAsync(new List<ReportData>()
            {
                new ReportData() { IdEik = 101, YearReport = 2017, AnnualTurnover=10000,  Assets=20000,CountOfEmployees=9},
               new ReportData() { IdEik = 101, YearReport = 2018, AnnualTurnover=10001,  Assets=20001,CountOfEmployees=10},
                new ReportData() { IdEik = 103, YearReport = 2019, AnnualTurnover=10002,  Assets=20002,CountOfEmployees=11},

            });

                await repo.SaveChangesAsync();

                bool firstTrueOption = await reportService.isReportExist(101, 2017);
                bool secondFalseOption = await reportService.isReportExist(101, 2016);

                Assert.That(firstTrueOption, Is.EqualTo(true));
                Assert.That(secondFalseOption, Is.EqualTo(false));

            }

            [Test]
            public async Task TestDeleteReport()
            {

                var repo = new Repository(context);
                reportService = new ReportService(repo);

                await repo.AddRangeAsync(new List<ReportData>()
            {
                new ReportData() { IdEik = 101, YearReport = 2017, AnnualTurnover=10000,  Assets=20000,CountOfEmployees=9},
               new ReportData() { IdEik = 101, YearReport = 2018, AnnualTurnover=10001,  Assets=20001,CountOfEmployees=10},
                new ReportData() { IdEik = 103, YearReport = 2019, AnnualTurnover=10002,  Assets=20002,CountOfEmployees=11},

            });

                await repo.SaveChangesAsync();


                await reportService.DeleteAsync(101, 2017);

                var currentDeleteReport = await reportService.GetReportAsync(101, 2017);
                var currentReport = await reportService.GetReportAsync(101, 2018);

                Assert.That(currentDeleteReport, Is.EqualTo(null));
                Assert.That(currentReport.YearReport, Is.EqualTo(2018));

            }


            [Test]
            public async Task TestEditReportInMemory()
            {


                var repo = new Repository(context);
                reportService = new ReportService(repo);

                await repo.AddAsync(new ReportData()
                {
                    IdEik = 101,
                    YearReport = 2017,
                    AnnualTurnover = 10000,
                    Assets = 20000,
                    CountOfEmployees = 9
                });


                await repo.SaveChangesAsync();

                await reportService.EditReportAsync(101, new ReportViewModel()
                {
                    IdEik = 101,
                    YearReport = 2017,
                    AnnualTurnover = 10001,
                    Assets = 20001,
                    CountOfEmployees = 10
                });

              

                var currentReport = await reportService.GetReportAsync(101,2017);

                Assert.That(101, Is.EqualTo(currentReport.IdEik));
                Assert.That(2017, Is.EqualTo(currentReport.YearReport));
                Assert.That(10001, Is.EqualTo(currentReport.AnnualTurnover));
                Assert.That(20001, Is.EqualTo(currentReport.Assets));
                Assert.That(10, Is.EqualTo(currentReport.CountOfEmployees));


            }

        }
    }
}
