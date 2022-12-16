using FinancialServices.Contracts;
using FinancialServices.Data;
using FinancialServices.Data.Common;
using FinancialServices.Models.Companies;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using Theatre.Data.Models;
using static FinancialServices.Services.CompanyService;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static NuGet.Packaging.PackagingConstants;

namespace FinancialServices.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly FinanceDbContext context;

        private readonly IRepository repo;

        public CompanyService(
            FinanceDbContext _context,
            IRepository _repo)
        {
            context = _context;
            repo = _repo;
        }



        public async Task<Company> GetCompanyAsync(long idEik)
        {
            var company = await context.Companies

                .Include(x => x.MapingManagers)
                    .ThenInclude(x => x.Person)
                .Include(x => x.MapingOwnerPersons)
                    .ThenInclude(x => x.Person)
                .Where(x => x.IdEik == idEik).
                FirstOrDefaultAsync();

            return company;
        }



        public async Task<CompanyInfoViewModel> CompanyDetailsById(long idEik)
        {

            var company = await GetCompanyAsync(idEik);

            List<Person> managers = await GetManagersAsync(idEik);

            List<MapingOwnerCompany> mapingOwnerCompanys = await GetCompanyOwnersDataAsync(idEik);

            List<Company> ownersCompanys = await GetCompanyOwnersAsync(mapingOwnerCompanys);

            CompanyInfoViewModel model = new CompanyInfoViewModel
            {
                IdEik = company.IdEik,
                CompanyName = company.CompanyName,
                AddressCompany = company.AddressCompany,
                AddressActivity = company.AddressActivity,
                KidNumber = company.KidNumber != null && company.KidNumber.Count() == 4 ? company.KidNumber.ToString() + "0" : company.KidNumber,
                Representing = company.Representing,
                TypeRepresenting = company.TypeRepresenting,
                TypeCompany = company.TypeCompany,
                ContactName = company.ContactName,
                PhoneNumber = company.PhoneNumber,
                Email = company.Email,
                Status = company.Status,
                Managers = managers,
                OwnersPersons = company.MapingOwnerPersons.Select(x => x.Person).ToList<Person>(),
                OwnersCompaniesData = mapingOwnerCompanys,
                OwnersCompanies = ownersCompanys

            };

            return model;
          
        }

        public async Task AddCompanyAsync(AddCompaniesViewModel model)
        {
            string kid = model.KidNumber;

            if (model.KidNumber != null)
            {
                kid = model.KidNumber.ToString();
                if (kid.Count() == 5 && kid[4].ToString() == "0")
                {
                    kid = kid.Substring(0, 4);
                }
            }


            var entity = new Company()
            {
                IdEik = model.IdEik,
                CompanyName = model.CompanyName,
                AddressCompany = model.AddressCompany,
                AddressActivity = model.AddressActivity,
                KidNumber = kid,
                Representing = model.Representing,
                TypeRepresenting = model.TypeRepresenting,
                TypeCompany = model.TypeCompany,
                ContactName = model.ContactName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Status = model.Status

            };



            await repo.AddAsync<Company>(entity);
            await repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(long idEik)
        {
            var company = await GetCompanyAsync(idEik);

           await repo.DeleteAsync<Company>(company.IdEik);

          //  context.Companies.Remove(company);

            await repo.SaveChangesAsync();
        }

        public async Task DeactivateAsync(long idEik)
        {
            var company = await GetCompanyAsync(idEik);

            company.Status = "Неактивна";

            await repo.SaveChangesAsync();
        }

        public async Task EditCompanyAsync(long idEik, AddCompaniesViewModel model)
        {
            var company = await GetCompanyAsync(idEik);

            string kid = model.KidNumber;

            if (model.KidNumber != null)
            {
                kid = model.KidNumber.ToString();
                if (kid.Count() == 5 && kid[4].ToString() == "0")
                {
                    kid = kid.Substring(0, 4);
                }
            }


            company.IdEik = model.IdEik;
            company.CompanyName = model.CompanyName;
            company.AddressCompany = model.AddressCompany;
            company.AddressActivity = model.AddressActivity;
            company.KidNumber = kid;
            company.Representing = model.Representing;
            company.TypeRepresenting = model.TypeRepresenting;
            company.TypeCompany = model.TypeCompany;
            company.ContactName = model.ContactName;
            company.PhoneNumber = model.PhoneNumber;
            company.Email = model.Email;
            company.Status = model.Status;

            await repo.SaveChangesAsync();
        }

      

        public async Task<IEnumerable<AllViewModel>> GetAllAsync()
        {

            return await repo.All<Company>()
                .Select(c => new AllViewModel()
                {
                    IdEik = c.IdEik,
                    CompanyName = c.CompanyName,
                    KidNumber = c.KidNumber != null && c.KidNumber.Count() == 4 ? c.KidNumber.ToString() + "0" : c.KidNumber,
                    Group = c.Kid.Group,
                    GroupName = c.Kid.GroupName,
                    PositionName = c.Kid.PositionName
                })
                .ToListAsync();

        }

       

        public async Task<List<MapingOwnerCompany>> GetCompanyOwnersDataAsync(long idEik)
        {

            var listCompanyData = await context.MapingOwnerCompanies
                .Include(x => x.Company)
                .Where(x => x.IdEik == idEik).ToListAsync();

            return listCompanyData;
        }

        public async Task<List<Company>> GetCompanyOwnersAsync(List<MapingOwnerCompany> listCompanyData)
        {

            List<Company> companyOwner = new List<Company>();

            foreach (var item in listCompanyData)
            {
                var currentCompany = await context.Companies.FirstOrDefaultAsync(x => x.IdEik == item.IdEikOwner);

                if (currentCompany != null)
                {
                    companyOwner.Add(currentCompany);
                }
            }

            return companyOwner;
        }

        public async Task<List<Person>> GetManagersAsync(long idEik)
        {
            var company = await context.Companies
                 .Include(x => x.MapingManagers)
                 .ThenInclude(x => x.Person)
                 .Where(x => x.IdEik == idEik)
                 .FirstOrDefaultAsync();


            if (company == null)
            {
                throw new ArgumentException("Invalid EIK");
            }


            List<Person> managers = company.MapingManagers.Select(x => x.Person).ToList<Person>();

            if (managers == null)
            {
                throw new ArgumentException("Invalid EIK");
            }

            return managers;
        }

   


        public async Task<IEnumerable<AllViewModel>> AllFilter(string? eik = null, string? companyName = null, string? kid = null, string? group = null)
        {


            var companies = repo.AllReadonly<Company>();


            if (string.IsNullOrEmpty(eik) == false)
            {

                eik = $"%{eik.ToLower()}%";

                companies = companies
                    .Where(c => EF.Functions.Like(c.IdEik.ToString().ToLower(), eik));


               
            }

            if (string.IsNullOrEmpty(companyName) == false)
            {
                companyName = $"%{companyName.ToLower()}%";

                companies = companies
                    .Where(c => EF.Functions.Like(c.CompanyName.ToLower(), companyName));
            }



            if (string.IsNullOrEmpty(group) == false)
            {
                string[] arr = group.Split(' ', StringSplitOptions.RemoveEmptyEntries);


                companies = companies.Where(file => arr.Any(filter => file.Kid.Group == (filter)));


            };


            if (string.IsNullOrEmpty(kid) == false)
            {
               


                string[] arr = kid.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int count = 0;

                foreach (var currentKid in arr)
                {
                    string newKid = currentKid;

                    if (currentKid != null)
                    {
                        newKid = currentKid.ToString();
                        if (newKid.Count() == 5 && newKid[4].ToString() == "0")
                        {
                            newKid = newKid.Substring(0, 4);
                        }
                    }

                    arr[count] = newKid;

                    count++;
                }

                companies = companies.Where(file => arr.Any(filter => file.KidNumber == (filter)));


            }

 

            var result = await companies
                .Select(c => new AllViewModel()
                {
                    IdEik = c.IdEik,
                    CompanyName = c.CompanyName,
                    KidNumber = c.KidNumber != null && c.KidNumber.Count() == 4 ? c.KidNumber.ToString() + "0" : c.KidNumber,
                    Group = c.Kid.Group,
                    GroupName = c.Kid.GroupName,
                    PositionName = c.Kid.PositionName
                })
                .ToListAsync();



            return result;
        }

        public async Task<bool> isCompanyExist(long idEik)
        {
         var company=  await repo.AllReadonly<Company>().FirstOrDefaultAsync(c=>c.IdEik == idEik);

            if (company==null)
            {
                return false;
            }

            return true;
        }
    }
}
