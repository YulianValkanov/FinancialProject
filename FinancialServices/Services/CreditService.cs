using FinancialServices.Contracts;
using FinancialServices.Data.Common;
using FinancialServices.Data.Models;
using FinancialServices.Models.Persons;
using FinancialServices.Models.Credits;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Theatre.Data.Models;

namespace FinancialServices.Services
{
    public class CreditService : ICreditService
    {
        private readonly IRepository repo;

        public CreditService(

            IRepository _repo)
        {

            repo = _repo;
        }

        public async Task AddCreditAsync(long idEik, AddCreditViewModel model)
        {

            var credit = new Credit()
            {
                IdEik = idEik,
                CreditNumber = model.CreditNumber,
                BeginValue = model.BeginValue,
                Rate = model.Rate,
                PresentValue = model.PresentValue
            };


            await repo.AddAsync(credit);

            await repo.SaveChangesAsync();
        }

        public async Task<DetailsCreditViewModel> GetAllAsync(long idEik)
        {
            string companyName = "";


            var company = await repo.AllReadonly<Company>()
               .FirstOrDefaultAsync(x => x.IdEik == idEik);

            if (company != null && company.CompanyName != null)
            {
                companyName = company.CompanyName;
            }

            var credits = await repo.AllReadonly<Credit>()
                .Where(x => x.IdEik == idEik)
                 .Select(c => new CreditViewModel()
                 {
                     CreditId = c.CreditId,
                     IdEik = c.IdEik,
                     CreditNumber = c.CreditNumber,
                     BeginValue = c.BeginValue,
                     Rate = c.Rate,
                     PresentValue = c.PresentValue

                 })
                 .OrderBy(x=>x.CreditNumber)
                .ToListAsync();

            var model = new DetailsCreditViewModel()
            {
                IdEik = idEik,
                CompanyName = companyName,
                Credits = credits
            };

            return model;
        }

        public async Task<bool> isCreditExist(long idEik, int CreditNumber)
        {
            var report = await repo.AllReadonly<Credit>()
                .FirstOrDefaultAsync(r => r.IdEik == idEik && r.CreditNumber == CreditNumber);

            if (report == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public async Task DeleteAsync(long idEik, int year)
        {
            var credit = await repo.All<Credit>()
                .Where(x => x.IdEik == idEik && x.CreditNumber == year)
               .FirstOrDefaultAsync();

            if (credit != null)
            {
                await repo.DeleteAsync<Credit>(credit.CreditId);

                await repo.SaveChangesAsync();
            }


        }

        public async Task<Credit> GetCreditAsync(long idEik, int year)
        {

            var credit = await repo.All<Credit>()
                .FirstOrDefaultAsync(x => x.IdEik == idEik && x.CreditNumber == year);


            return credit;
        }

        public async Task EditCreditAsync(long idEik, CreditViewModel model)
        {
            var credit = await GetCreditAsync(idEik, model.CreditNumber);


            credit.BeginValue = model.BeginValue;
            credit.Rate = model.Rate;
            credit.PresentValue = model.PresentValue;


            await repo.SaveChangesAsync();

        }
    }
}
