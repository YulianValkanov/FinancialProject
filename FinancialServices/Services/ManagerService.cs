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
    public class ManagerService: IManagerService
    {

        private readonly IRepository repo;
        private readonly FinanceDbContext context;

        public ManagerService(           
            IRepository _repo)
        {           
            repo = _repo;
        }

        public async Task AddManagerAsync(long idEik,AddManagerViewModel model)
        {           
                var entity = new MapingManager()
                {
                    IdEgn = model.IdEgn,
                    IdEik = idEik
                };

                await repo.AddAsync<MapingManager>(entity);
                await repo.SaveChangesAsync();
                      
        }

        public async Task DeleteAsync(long idEik, long idEgn)
        {       
            var mapingManager = await repo.AllReadonly<MapingManager >().FirstOrDefaultAsync(x => x.IdEgn == idEgn && x.IdEik == idEik);

            if (mapingManager!=null)
            {
                repo.Delete<MapingManager>(mapingManager);

                await repo.SaveChangesAsync();
            }

        }
    }
}
