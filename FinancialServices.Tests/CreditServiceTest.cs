using FinancialServices.Contracts;
using FinancialServices.Data.Common;
using FinancialServices.Data.Models;
using FinancialServices.Data;
using FinancialServices.Models.Reports;
using FinancialServices.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialServices.Models.Credits;

namespace FinancialServices.Tests
{
    public class CreditServiceTest
    {
        [TestFixture]
        public class CompanyServiceTests
        {
            private IRepository repo;
            private ICreditService creditService;
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
                creditService = new CreditService(repo);

                await repo.AddRangeAsync(new List<Credit>()
            {
                new Credit() { IdEik = 101, CreditNumber = 2017, BeginValue=10000,  PresentValue=20000,Rate=9},
               new Credit() { IdEik = 102, CreditNumber = 2018, BeginValue=10001,  PresentValue=20001,Rate=10},
                new Credit() { IdEik = 103, CreditNumber = 2019, BeginValue=10002,  PresentValue=20002,Rate=11},
            });

                await repo.SaveChangesAsync();
                var currentCredit = await creditService.GetCreditAsync(101, 2017);

                Assert.That(2017, Is.EqualTo(currentCredit.CreditNumber));
                Assert.That(10000, Is.EqualTo(currentCredit.BeginValue));
                Assert.That(20000, Is.EqualTo(currentCredit.PresentValue));
                Assert.That(9, Is.EqualTo(currentCredit.Rate));

                Assert.That(1, Is.EqualTo(currentCredit.CreditId));

            }



            [Test]
            public async Task TestAddReportAsync()
            {

                var repo = new Repository(context);
                creditService = new CreditService(repo);

                var model = new AddCreditViewModel()
                {
                    IdEik = 123,
                    CreditNumber = 2017,
                    BeginValue = 55000,
                    PresentValue = 44000,
                    Rate = 9
                };
                await creditService.AddCreditAsync(123, model);


                var currentCredit = await creditService.GetCreditAsync(123, 2017);

                Assert.That(123, Is.EqualTo(currentCredit.IdEik));
                Assert.That(2017, Is.EqualTo(currentCredit.CreditNumber));
                Assert.That(55000, Is.EqualTo(currentCredit.BeginValue));
                Assert.That(44000, Is.EqualTo(currentCredit.PresentValue));
                Assert.That(9, Is.EqualTo(currentCredit.Rate));

            }


            [Test]
            public async Task TestGetAllAsync()
            {
                var repo = new Repository(context);
                creditService = new CreditService(repo);

                await repo.AddRangeAsync(new List<Credit>()
            {
                new Credit() { IdEik = 101, CreditNumber = 2017, BeginValue=10000,  PresentValue=20000,Rate=9},
               new Credit() { IdEik = 101, CreditNumber = 2018, BeginValue=10001,  PresentValue=20001,Rate=10},
                new Credit() { IdEik = 103, CreditNumber = 2019, BeginValue=10002,  PresentValue=20002,Rate=11},
            });

                await repo.SaveChangesAsync();

                var currentCredit = await creditService.GetAllAsync(101);


                Assert.That(currentCredit.Credits.Count(), Is.EqualTo(2));
                Assert.That(currentCredit.IdEik, Is.EqualTo(101));

            }



            [Test]
            public async Task TestisReportExist()
            {
                var repo = new Repository(context);
                creditService = new CreditService(repo);

                await repo.AddRangeAsync(new List<Credit>()
            {
                new Credit() { IdEik = 101, CreditNumber = 2017, BeginValue=10000,  PresentValue=20000,Rate=9},
               new Credit() { IdEik = 102, CreditNumber = 2018, BeginValue=10001,  PresentValue=20001,Rate=10},
                new Credit() { IdEik = 103, CreditNumber = 2019, BeginValue=10002,  PresentValue=20002,Rate=11},
            });

                await repo.SaveChangesAsync();

                bool firstTrueOption = await creditService.isCreditExist(101, 2017);
                bool secondFalseOption = await creditService.isCreditExist(101, 2016);

                Assert.That(firstTrueOption, Is.EqualTo(true));
                Assert.That(secondFalseOption, Is.EqualTo(false));

            }

            [Test]
            public async Task TestDeleteReport()
            {

                var repo = new Repository(context);
                creditService = new CreditService(repo);

                await repo.AddRangeAsync(new List<Credit>()
            {
                new Credit() { IdEik = 101, CreditNumber = 2017, BeginValue=10000,  PresentValue=20000,Rate=9},
               new Credit() { IdEik = 101, CreditNumber = 2018, BeginValue=10001,  PresentValue=20001,Rate=10},
                new Credit() { IdEik = 103, CreditNumber = 2019, BeginValue=10002,  PresentValue=20002,Rate=11},
            });

                await repo.SaveChangesAsync();


                await creditService.DeleteAsync(101, 2017);

                var currentDeleteReport = await creditService.GetCreditAsync(101, 2017);
                var currentReport = await creditService.GetCreditAsync(101, 2018);

                Assert.That(currentDeleteReport, Is.EqualTo(null));
                Assert.That(currentReport.CreditNumber, Is.EqualTo(2018));

            }


            [Test]
            public async Task TestEditReportInMemory()
            {


                var repo = new Repository(context);
                creditService = new CreditService(repo);

                await repo.AddAsync(new Credit()
                {
                    IdEik = 101,
                    CreditNumber = 2017,
                    BeginValue = 10000,
                    PresentValue = 20000,
                    Rate = 9
                });


                await repo.SaveChangesAsync();

                await creditService.EditCreditAsync(101, new CreditViewModel()
                {
                    IdEik = 101,
                    CreditNumber = 2017,
                    BeginValue = 10001,
                    PresentValue = 20001,
                    Rate = 10
                });



                var currentCredit = await creditService.GetCreditAsync(101, 2017);

                Assert.That(101, Is.EqualTo(currentCredit.IdEik));
                Assert.That(2017, Is.EqualTo(currentCredit.CreditNumber));
                Assert.That(10001, Is.EqualTo(currentCredit.BeginValue));
                Assert.That(20001, Is.EqualTo(currentCredit.PresentValue));
                Assert.That(10, Is.EqualTo(currentCredit.Rate));


            }


        }
    }
}
