using FinancialServices.Constants;
using FinancialServices.Contracts;
using FinancialServices.Data.Common;
using FinancialServices.Models.Companies;
using FinancialServices.Models.Persons;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> isPersonExist(long idEgn)
        {
            var person = await repo.AllReadonly<Person>().FirstOrDefaultAsync(c => c.IdEgn == idEgn);

            if (person == null)
            {
                return false;
            }

            return true;
        }


        public async Task<IEnumerable<AllPersonViewModel>> AllFilter(string? egn = null, string? firstName = null, string? lastName = null)
        {

            var persons = repo.AllReadonly<Person>();


            if (string.IsNullOrEmpty(egn) == false)
            {

                egn = $"%{egn.ToLower()}%";

                persons = persons
                    .Where(c => EF.Functions.Like(c.IdEgn.ToString().ToLower(), egn));

            }

            if (string.IsNullOrEmpty(firstName) == false)
            {
                firstName = $"%{firstName.ToLower()}%";

                persons = persons
                    .Where(c => EF.Functions.Like(c.FirstName.ToLower(), firstName));
            }

            if (string.IsNullOrEmpty(lastName) == false)
            {
                lastName = $"%{lastName.ToLower()}%";

                persons = persons
                    .Where(c => EF.Functions.Like(c.LastName.ToLower(), lastName));
            }



            var result = await persons
                .Select(c => new AllPersonViewModel()
                {
                  IdEgn=c.IdEgn,
                  FirstName=c.FirstName,
                  SecondName=c.SecondName,
                  LastName=c.LastName
                })
                .ToListAsync();



            return result;
        }


        public async Task<Person> GetPersonAsync(long idEgn)
        {
            var person = await repo.GetByIdAsync<Person>(idEgn);
              
            return person;
        }

        public async Task EditPersonAsync(long idEgn, AddPersonViewModel model)
        {
            var company = await GetPersonAsync(idEgn);

            if (idEgn==model.IdEgn)
            {

                company.IdEgn = model.IdEgn;
                company.FirstName = model.FirstName;
                company.SecondName = model.SecondName;
                company.LastName = model.LastName;

                await repo.SaveChangesAsync();

            }

           
        }

        public async Task DeleteAsync(long idEgn)
        {
            var person = await GetPersonAsync(idEgn);

            await repo.DeleteAsync<Person>(idEgn);

            await repo.SaveChangesAsync();
        }
    }
}
