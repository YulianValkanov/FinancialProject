using FinancialServices.Constants;
using FinancialServices.Contracts;
using FinancialServices.Data.Common;
using FinancialServices.Models.Persons;
using Theatre.Data.Models;


namespace FinancialServices.Services
{
    public class PersonService : IPersonService
    {

        private readonly IRepository repo;

        public PersonService(
           
            IRepository _repo)
        {
           
            repo = _repo;
        }


        public async Task AddPersonAsync(AddPersonViewModel model)
        {

            Person person = await repo.GetByIdAsync<Person>(model.IdEgn);

            //if (person == null)
            //{
                var entity = new Person()
                {
                    IdEgn = model.IdEgn,
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    LastName = model.LastName,
                };

                await repo.AddAsync(entity);
                await repo.SaveChangesAsync();

            //}
            //else
            //{
            //    person.IdEgn = model.IdEgn;
            //    person.FirstName = model.FirstName;
            //    person.SecondName = model.SecondName;
            //    person.LastName = model.LastName;
            //    await repo.SaveChangesAsync();
            //}

            
        }
    }
}
