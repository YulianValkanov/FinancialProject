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
    public class OwnerCompanyService : IOwnerCompanyService
    {

        private readonly IRepository repo;
        private readonly FinanceDbContext context;

        public OwnerCompanyService(
           
            IRepository _repo)
        {
           
            repo = _repo;
        }

        public async Task AddOwnerAsync(long idEik,AddOwnerCompanyViewModel model)
        {
           
            double persent = model.Persent/100;

            var entity = new MapingOwnerCompany()
            {             
                IdEik = idEik,
                IdEikOwner=model.OwnerEik,
                Persent = persent

            };
            await repo.AddAsync<MapingOwnerCompany >(entity);
            await repo.SaveChangesAsync();
        }

     

        public async Task DeleteAsync(long idEik, long ownerEik)
        {       
            var mapingOwnerCompany = await repo.AllReadonly<MapingOwnerCompany >().FirstOrDefaultAsync(x => x.IdEik == idEik && x.IdEikOwner == ownerEik);

            if (mapingOwnerCompany != null)
            {
                repo.Delete<MapingOwnerCompany>(mapingOwnerCompany);

                await repo.SaveChangesAsync();
            }

        }
    }
}
