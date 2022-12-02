using FinancialServices.Contracts;
using FinancialServices.Data;
using FinancialServices.Data.Common;
using FinancialServices.Models;
using FinancialServices.Models.Persons;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using Theatre.Data.Models;

namespace FinancialServices.Services
{
    public class OwnerPersonService : IOwnerPersonService
    {

        private readonly IRepository repo;
        private readonly FinanceDbContext context;

        public OwnerPersonService(
           
            IRepository _repo)
        {
           
            repo = _repo;
        }


        public async Task AddOwnerAsync(long idEik,AddOwnerPersonViewModel model)
        {
           

            double persent = model.Persent/100;

            var entity = new MapingOwnerPerson()
            {
                IdEgn = model.IdEgn,
                IdEik = ((int)idEik),
                Persent = persent

            };

            await repo.AddAsync<MapingOwnerPerson >(entity);
            await repo.SaveChangesAsync();
        }

     

        public async Task DeleteAsync(long idEik, long idEgn)
        {       
            var mapingOwnerPerson = await repo.AllReadonly<MapingOwnerPerson >().FirstOrDefaultAsync(x => x.IdEgn == idEgn && x.IdEik == idEik);

            if (mapingOwnerPerson != null)
            {
                repo.Delete<MapingOwnerPerson>(mapingOwnerPerson);

                await repo.SaveChangesAsync();
            }

        }
    }
}
