using FinancialServices.Contracts;
using FinancialServices.Data.Common;
using FinancialServices.Data;
using FinancialServices.Models.Companies;
using FinancialServices.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Data.Models;
using FinancialServices.Models.Persons;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace FinancialServices.Tests
{
    public class PersonServiceTests
    {

        [TestFixture]
        public class CompanyServiceTests
        {
            private IRepository repo;
            private IPersonService personService;
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
            public async Task TestGetPersonAsync()
            {

                var repo = new Repository(context);
                personService = new PersonService(repo);

                await repo.AddRangeAsync(new List<Person>()
            {
                new Person() { IdEgn = 1, FirstName = "FirstName1", SecondName="SecondName1",  LastName="LastName1"},
                new Person() { IdEgn = 2, FirstName = "FirstName2", SecondName="SecondName2",  LastName="LastName2"},
                new Person() { IdEgn = 3, FirstName = "FirstName3", SecondName="SecondName3",  LastName="LastName3"},

            });

                await repo.SaveChangesAsync();
                var currentPerson = await personService.GetPersonAsync(2);

                Assert.That("FirstName2", Is.EqualTo(currentPerson.FirstName));
                Assert.That("SecondName2", Is.EqualTo(currentPerson.SecondName));
                Assert.That("LastName2", Is.EqualTo(currentPerson.LastName));

                Assert.That(2, Is.EqualTo(currentPerson.IdEgn));

            }

            [Test]
            public async Task TestAdedCompanyAsyncInMemory()
            {

                var repo = new Repository(context);
                personService = new PersonService(repo);

                var model = new AddPersonViewModel()
                {
                    IdEgn = 3,
                    FirstName = "FirstName3",
                    SecondName = "SecondName3",
                    LastName = "LastName3"
                };

                await personService.AddPersonAsync(model);

                var currentPerson = await personService.GetPersonAsync(3);

                Assert.That(3, Is.EqualTo(currentPerson.IdEgn));
                Assert.That("FirstName3", Is.EqualTo(currentPerson.FirstName));
                Assert.That("SecondName3", Is.EqualTo(currentPerson.SecondName));
                Assert.That("LastName3", Is.EqualTo(currentPerson.LastName));


            }


            [Test]
            public async Task TestisPersonExist()
            {

                var repo = new Repository(context);
                personService = new PersonService(repo);

                await repo.AddRangeAsync(new List<Person>()
            {
                new Person() { IdEgn = 1, FirstName = "FirstName1", SecondName="SecondName1",  LastName="LastName1"},
                new Person() { IdEgn = 2, FirstName = "FirstName2", SecondName="SecondName2",  LastName="LastName2"},
                new Person() { IdEgn = 3, FirstName = "FirstName3", SecondName="SecondName3",  LastName="LastName3"},

            });

                await repo.SaveChangesAsync();

                bool firstTrueOption = await personService.isPersonExist(3);
                bool secondFalseOption = await personService.isPersonExist(4);

                Assert.That(firstTrueOption, Is.EqualTo(true));
                Assert.That(secondFalseOption, Is.EqualTo(false));

            }


            [Test]
            public async Task AllFilter()
            {

                var repo = new Repository(context);
                personService = new PersonService(repo);

                await repo.AddRangeAsync(new List<Person>()
            {
               new Person() { IdEgn = 1, FirstName = "FirstName1", SecondName="SecondName1",  LastName="LastName1"},
                new Person() { IdEgn = 2, FirstName = "FirstName2", SecondName="SecondName2",  LastName="LastName2"},
                new Person() { IdEgn = 3, FirstName = "FirstName3", SecondName="SecondName3",  LastName="LastName3"},

            });

                await repo.SaveChangesAsync();

                var companies = await personService.AllFilter();

                Assert.That(companies.Count(), Is.EqualTo(3));

            }


            [Test]
            public async Task AllFilterEgn()
            {

                var repo = new Repository(context);
                personService = new PersonService(repo);

                await repo.AddRangeAsync(new List<Person>()
            {
               new Person() { IdEgn = 1, FirstName = "FirstName1", SecondName="SecondName1",  LastName="LastName1"},
                new Person() { IdEgn = 2, FirstName = "FirstName2", SecondName="SecondName2",  LastName="LastName2"},
                new Person() { IdEgn = 3, FirstName = "FirstName3", SecondName="SecondName3",  LastName="LastName3"},

            });

                await repo.SaveChangesAsync();

                var companies = await personService.AllFilter("3");

                Assert.That(companies.Count(), Is.EqualTo(1));

            }

            [Test]
            public async Task AllFilterFirstName()
            {

                var repo = new Repository(context);
                personService = new PersonService(repo);

                await repo.AddRangeAsync(new List<Person>()
            {
               new Person() { IdEgn = 1, FirstName = "FirstName1", SecondName="SecondName1",  LastName="LastName1"},
                new Person() { IdEgn = 2, FirstName = "FirstName2", SecondName="SecondName2",  LastName="LastName2"},
                new Person() { IdEgn = 3, FirstName = "FirstName3", SecondName="SecondName3",  LastName="LastName3"},

            });

                await repo.SaveChangesAsync();

                var companies = await personService.AllFilter("", "FirstName2");

                Assert.That(companies.Count(), Is.EqualTo(1));

            }

            [Test]
            public async Task AllFilterLastName()
            {

                var repo = new Repository(context);
                personService = new PersonService(repo);

                await repo.AddRangeAsync(new List<Person>()
            {
               new Person() { IdEgn = 1, FirstName = "FirstName1", SecondName="SecondName1",  LastName="LastName1"},
                new Person() { IdEgn = 2, FirstName = "FirstName2", SecondName="SecondName2",  LastName="LastName2"},
                new Person() { IdEgn = 3, FirstName = "FirstName3", SecondName="SecondName3",  LastName="LastName3"},

            });

                await repo.SaveChangesAsync();

                var companies = await personService.AllFilter("", "", "lastname2");

                Assert.That(companies.Count(), Is.EqualTo(1));

            }


            [Test]
            public async Task TestEditPersonInMemory()
            {

                var repo = new Repository(context);
                personService = new PersonService( repo);

                var model = new AddPersonViewModel()
                {
                    IdEgn = 3,
                    FirstName = "FirstName3",
                    SecondName = "SecondName3",
                    LastName = "LastName3"
                };

                await personService.AddPersonAsync(model);




                await personService.EditPersonAsync(3, new AddPersonViewModel()
                {
                    IdEgn = 3,
                    FirstName = "FirstName3Edit",
                    SecondName = "SecondName3Edit",
                    LastName = "LastName3Edit"
                });



                var currentPerson = await personService.GetPersonAsync(3);

                Assert.That(3, Is.EqualTo(currentPerson.IdEgn));
                Assert.That("FirstName3Edit", Is.EqualTo(currentPerson.FirstName));
                Assert.That("SecondName3Edit", Is.EqualTo(currentPerson.SecondName));
                Assert.That("LastName3Edit", Is.EqualTo(currentPerson.LastName));


            }


            [Test]
            public async Task TestDeletePErsonAsyncInMemory()
            {

                var repo = new Repository(context);
                personService = new PersonService(repo);

                var model = new AddPersonViewModel()
                {
                    IdEgn = 3,
                    FirstName = "FirstName3",
                    SecondName = "SecondName3",
                    LastName = "LastName3"
                };

                await personService.AddPersonAsync(model);


                await personService.DeleteAsync(3);

                var currentPerson = await personService.GetPersonAsync(3);

                Assert.That(currentPerson, Is.EqualTo(null));

            }
        }
    }
}
