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
using FinancialServices.Models;
using Theatre.Data.Models;

namespace FinancialServices.Tests
{
    public class ManagerServiceTest
    {
        [TestFixture]
        public class CompanyServiceTests
        {
            private IRepository repo;
            private IManagerService managerService;
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
            public async Task TestAdedCompanyAsyncInMemory()
            {

                var repo = new Repository(context);
                managerService = new ManagerService(repo);

                var model = new AddManagerViewModel()
                {
                    IdEik = 3,
                    IdEgn = 4

                };

                await managerService.AddManagerAsync(3,model);

                var currentManager = await repo.All<MapingManager>().FirstOrDefaultAsync(x=>x.IdEik==3);

                Assert.That(4, Is.EqualTo(currentManager.IdEgn));
               
            }

            [Test]
            public async Task TestDeleteAsync()
            {

                var repo = new Repository(context);
                managerService = new ManagerService(repo);

                var model = new AddManagerViewModel()
                {
                    IdEik = 999,
                    IdEgn = 999

                };

                await managerService.AddManagerAsync(3, model);
   
                await managerService.DeleteAsync(999, 999);
                             

                var mapingManager = await repo.AllReadonly<MapingManager>().FirstOrDefaultAsync(x => x.IdEgn == 999 && x.IdEik == 999);
             
                Assert.That(mapingManager, Is.EqualTo(null));
            }

        }
    }
}
