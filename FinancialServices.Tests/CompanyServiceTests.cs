using FinancialServices.Contracts;
using FinancialServices.Data;
using FinancialServices.Data.Common;
using FinancialServices.Models.Companies;
using FinancialServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Theatre.Data.Models;

namespace FinancialServices.Tests
{


    [TestFixture]
    public class CompanyServiceTests
    {
        private IRepository repo;
        private ICompanyService companyService;
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
        public async Task TestGetCompanyAsyncInMemory()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            await context.AddRangeAsync(new List<Company>()
            {
                new Company() { IdEik = 1, CompanyName = "Test1"},
                new Company() { IdEik = 2, CompanyName = "Test2"},
                new Company() { IdEik = 3, CompanyName = "Test3"}

            });

            await context.SaveChangesAsync();
            var currentCompany = await companyService.GetCompanyAsync(2);

            Assert.That("Test2", Is.EqualTo(currentCompany.CompanyName));
            Assert.That(2, Is.EqualTo(currentCompany.IdEik));

        }

        [Test]
        public async Task TestGetCompanyThatNotExistAsyncInMemory()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            await context.AddRangeAsync(new List<Company>()
            {
                new Company() { IdEik = 1, CompanyName = "Test1"},
                new Company() { IdEik = 2, CompanyName = "Test2"},
                new Company() { IdEik = 3, CompanyName = "Test3"}

            });

            await context.SaveChangesAsync();
            var currentCompany = await companyService.GetCompanyAsync(4);

            Assert.That(currentCompany, Is.EqualTo(null));
      
        }


        [Test]
        public async Task TestAdedCompanyAsyncInMemory()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            var model = new AddCompaniesViewModel()             
                { 
                IdEik = 3,
                CompanyName = "Test3",
                AddressCompany = "Adress3",
                AddressActivity = "Adress3",
                KidNumber = "55",
                Representing = "manager",
                TypeRepresenting = "single",
                TypeCompany = "small",
                ContactName = "name",
                PhoneNumber = "0888778899",
                Email = "test@abv.bg",
                Status = "active"              
            };

            await companyService.AddCompanyAsync(model);
                 
            var currentCompany = await companyService.GetCompanyAsync(3);

            Assert.That(3, Is.EqualTo(currentCompany.IdEik));
            Assert.That("Test3", Is.EqualTo(currentCompany.CompanyName));
            Assert.That("Adress3", Is.EqualTo(currentCompany.AddressCompany));
            Assert.That("Adress3", Is.EqualTo(currentCompany.AddressActivity));
            Assert.That("55", Is.EqualTo(currentCompany.KidNumber));
            Assert.That("manager", Is.EqualTo(currentCompany.Representing));
            Assert.That("single", Is.EqualTo(currentCompany.TypeRepresenting));
            Assert.That("small", Is.EqualTo(currentCompany.TypeCompany));
            Assert.That("name", Is.EqualTo(currentCompany.ContactName));
            Assert.That("0888778899", Is.EqualTo(currentCompany.PhoneNumber));
            Assert.That("test@abv.bg", Is.EqualTo(currentCompany.Email));
            Assert.That("active", Is.EqualTo(currentCompany.Status));

        }

        [Test]
        public async Task TestDeleteCompanyAsyncInMemory()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            var model = new AddCompaniesViewModel()
            {
                IdEik = 3,
                CompanyName = "Test3",
                AddressCompany = "Adress3",
                AddressActivity = "Adress3",
                KidNumber = "55",
                Representing = "manager",
                TypeRepresenting = "single",
                TypeCompany = "small",
                ContactName = "name",
                PhoneNumber = "0888778899",
                Email = "test@abv.bg",
                Status = "active"
            };

            await companyService.AddCompanyAsync(model);

            await companyService.DeleteAsync(3);

            var currentCompany = await companyService.GetCompanyAsync(3);

            Assert.That(currentCompany, Is.EqualTo(null));

        }

        [Test]
        public async Task TestDeactivateCompanyAsyncInMemory()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            var model = new AddCompaniesViewModel()
            {
                IdEik = 3,
                CompanyName = "Test3",       
                Status = "active"
            };

            await companyService.AddCompanyAsync(model);

            await companyService.DeactivateAsync(3);

            var currentCompany = await companyService.GetCompanyAsync(3);

            Assert.That(currentCompany.Status, Is.EqualTo("Неактивна"));

        }

        [Test]
        public async Task TestEditCompanyAsyncInMemory()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            var model = new AddCompaniesViewModel()
            {
                IdEik = 3,
                CompanyName = "",
                AddressCompany = "",
                AddressActivity = "",
                KidNumber = "",
                Representing = "",
                TypeRepresenting = "",
                TypeCompany = "",
                ContactName = "",
                PhoneNumber = "",
                Email = "",
                Status = ""
            };

            await companyService.AddCompanyAsync(model);




            await companyService.EditCompanyAsync(3,new AddCompaniesViewModel()     
            {
                IdEik = 3,
                CompanyName = "Test3",
                AddressCompany = "Adress3",
                AddressActivity = "Adress3",
                KidNumber = "55",
                Representing = "manager",
                TypeRepresenting = "single",
                TypeCompany = "small",
                ContactName = "name",
                PhoneNumber = "0888778899",
                Email = "test@abv.bg",
                Status = "active"
            });



            var currentCompany = await companyService.GetCompanyAsync(3);

            Assert.That(3, Is.EqualTo(currentCompany.IdEik));
            Assert.That("Test3", Is.EqualTo(currentCompany.CompanyName));
            Assert.That("Adress3", Is.EqualTo(currentCompany.AddressCompany));
            Assert.That("Adress3", Is.EqualTo(currentCompany.AddressActivity));
            Assert.That("55", Is.EqualTo(currentCompany.KidNumber));
            Assert.That("manager", Is.EqualTo(currentCompany.Representing));
            Assert.That("single", Is.EqualTo(currentCompany.TypeRepresenting));
            Assert.That("small", Is.EqualTo(currentCompany.TypeCompany));
            Assert.That("name", Is.EqualTo(currentCompany.ContactName));
            Assert.That("0888778899", Is.EqualTo(currentCompany.PhoneNumber));
            Assert.That("test@abv.bg", Is.EqualTo(currentCompany.Email));
            Assert.That("active", Is.EqualTo(currentCompany.Status));

        }

        [Test]
        public async Task TestGetAllAsyncInMemory()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            await repo.AddRangeAsync(new List<Company>()
            {
                new Company() { IdEik = 1, CompanyName = "Test1"},
                new Company() { IdEik = 2, CompanyName = "Test2"},
                new Company() { IdEik = 3, CompanyName = "Test3"}

            });

            await context.SaveChangesAsync();

            var allCompany =await companyService.GetAllAsync();

            Assert.That(allCompany.Count(), Is.EqualTo(3));

        }


        [Test]
        public async Task TestGetCompanyOwnersDataAsync()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            await context.AddRangeAsync(new List<Company>()
            {
                new Company() { IdEik = 1, CompanyName = "Test1"},
                new Company() { IdEik = 2, CompanyName = "Test2"},
                new Company() { IdEik = 3, CompanyName = "Test3"}

            });

            await context.SaveChangesAsync();
            var currentCompany = await companyService.GetCompanyAsync(3);

            var companyOwner = new MapingOwnerCompany()
            {
                IdEik = 3,
                IdEikOwner = 2
            };


            await context.AddAsync<MapingOwnerCompany>(companyOwner);
            await context.SaveChangesAsync();

            var manager = companyService.GetCompanyOwnersDataAsync(3);

            Assert.That(true, Is.EqualTo( currentCompany.MapingOwnerCompanies.Any(x=>x.IdEikOwner==2)));
          

        }



        [Test]
        public async Task GetManagersAsync()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            await context.AddRangeAsync(new List<Company>()
            {
                new Company() { IdEik = 1, CompanyName = "Test1"},
                new Company() { IdEik = 2, CompanyName = "Test2"},
                new Company() { IdEik = 3, CompanyName = "Test3"}

            });

            await context.SaveChangesAsync();
            var currentCompany = await companyService.GetCompanyAsync(3);

            var companyOwner = new MapingOwnerCompany()
            {
                IdEik = 3,
                IdEikOwner = 2
            };


            await context.AddAsync<MapingOwnerCompany>(companyOwner);
            await context.SaveChangesAsync();

            var manager = companyService.GetManagersAsync(3);

            Assert.That(true, Is.EqualTo(currentCompany.MapingOwnerCompanies.Any(x => x.IdEikOwner == 2)));


        }


        [Test]
        public async Task isCompanyExist()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            await context.AddRangeAsync(new List<Company>()
            {
                new Company() { IdEik = 1, CompanyName = "Test1"},
                new Company() { IdEik = 2, CompanyName = "Test2"},
                new Company() { IdEik = 3, CompanyName = "Test3"}

            });

            await context.SaveChangesAsync();

            bool firstTrueOption =await companyService.isCompanyExist(3);
            bool secondFalseOption = await companyService.isCompanyExist(4);

            Assert.That(firstTrueOption, Is.EqualTo(true));
            Assert.That(secondFalseOption, Is.EqualTo(false));

        }

        [Test]
        public async Task AllFilter()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            await context.AddRangeAsync(new List<Company>()
            {
                new Company() { IdEik = 1, CompanyName = "Test1"},
                new Company() { IdEik = 2, CompanyName = "Test2"},
                new Company() { IdEik = 3, CompanyName = "Test3"}

            });

            await context.SaveChangesAsync();

            var companies = await companyService.AllFilter();

            Assert.That(companies.Count(), Is.EqualTo(3));
           
        }

        [Test]
        public async Task AllFilterEik()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            await context.AddRangeAsync(new List<Company>()
            {
                new Company() { IdEik = 1, CompanyName = "Test1"},
                new Company() { IdEik = 2, CompanyName = "Test2"},
                new Company() { IdEik = 3, CompanyName = "Test3"}

            });

            await context.SaveChangesAsync();

            var companies = await companyService.AllFilter("3");

            Assert.That(companies.Count(), Is.EqualTo(1));

        }

        [Test]
        public async Task AllFiltername()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            await context.AddRangeAsync(new List<Company>()
            {
                new Company() { IdEik = 1, CompanyName = "Test1", KidNumber="11"},
                new Company() { IdEik = 2, CompanyName = "Test2", KidNumber="22"},
                new Company() { IdEik = 3, CompanyName = "Test3", KidNumber="33"}

            });

            await context.SaveChangesAsync();

            var companies = await companyService.AllFilter("","Test2");

            Assert.That(companies.Count(), Is.EqualTo(1));

        }

        [Test]
        public async Task AllFilterKid()
        {

            var repo = new Repository(context);
            companyService = new CompanyService(context, repo);

            await context.AddRangeAsync(new List<Company>()
            {
                new Company() { IdEik = 1, CompanyName = "Test1", KidNumber="11"},
                new Company() { IdEik = 2, CompanyName = "Test2", KidNumber="22"},
                new Company() { IdEik = 3, CompanyName = "Test3", KidNumber="33"}

            });

            await context.SaveChangesAsync();

            var companies = await companyService.AllFilter("", "","22 33");

            Assert.That(companies.Count(), Is.EqualTo(2));

        }
    }



}
