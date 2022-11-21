using FinancialServices.Contracts;
using FinancialServices.Data;
using FinancialServices.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Theatre.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinancialServices.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly FinanceDbContext context;

        public CompanyService(FinanceDbContext _context)
        {
            context = _context;
        }


        public async Task AddCompanyAsync(AddCompaniesViewModel model)
        {
            string kid=model.KidNumber;

            if (model.KidNumber!=null)
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


            await context.Companies.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long idEik)
        {
            var company = await GetCompanyAsync(idEik);

            context.Companies.Remove(company);

           await context.SaveChangesAsync();
        }

        public async Task DeactivateAsync(long idEik)
        {
            var company = await GetCompanyAsync(idEik);

            company.Status = "Неактивна";

            await context.SaveChangesAsync();
        }

        public async Task EditCompanyAsync(long idEik,AddCompaniesViewModel model)
        {
            var company =await GetCompanyAsync(idEik);

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

            await context.SaveChangesAsync();
        }

        //public async Task AddMovieToCollectionAsync(int movieId, string userId)
        //{
        //    var user = await context.Users
        //        .Where(u => u.Id == userId)
        //        .Include(u => u.UsersMovies)
        //        .FirstOrDefaultAsync();

        //    if (user == null)
        //    {
        //        throw new ArgumentException("Invalid user ID");
        //    }

        //    var movie = await context.Movies.FirstOrDefaultAsync(u => u.Id == movieId);

        //    if (movie == null)
        //    {
        //        throw new ArgumentException("Invalid Movie ID");
        //    }

        //    if (!user.UsersMovies.Any(m => m.MovieId == movieId))
        //    {
        //        user.UsersMovies.Add(new UserMovie()
        //        {
        //            MovieId = movie.Id,
        //            UserId = user.Id,
        //            Movie = movie,
        //            User = user
        //        });

        //        await context.SaveChangesAsync();
        //    }
        //}

        public async Task<IEnumerable<AllViewModel>> GetAllAsync()
        {

            return await context.Companies
                .Select(c => new AllViewModel()
                {
                    IdEik = c.IdEik,
                    CompanyName = c.CompanyName,
                    KidNumber = c.KidNumber !=null &&c.KidNumber.Count()==4 ? c.KidNumber.ToString()+"0" : c.KidNumber,
                    Group = c.Kid.Group,
                    GroupName = c.Kid.GroupName,
                    PositionName = c.Kid.PositionName
                })
                .ToListAsync();

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

            if (company == null)
            {
                throw new ArgumentException("Invalid EIK");
            }
       

            return company;
        }

        public async Task<List<MapingOwnerCompany>> GetCompanyOwnersDataAsync(long idEik)
        {

            var listCompanyData = await context.MapingOwnerCompanies
                .Include(x=>x.Company)
                .Where(x => x.IdEik == idEik).ToListAsync();

            return listCompanyData;
        }

        public async Task< List<Company>> GetCompanyOwnersAsync(List<MapingOwnerCompany> listCompanyData)
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



        //public async Task<IEnumerable<Genre>> GetGenresAsync()
        //{
        //    return await context.Genres.ToListAsync();
        //}

        //public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
        //{
        //    var user = await context.Users
        //        .Where(u => u.Id == userId)
        //        .Include(u => u.UsersMovies)
        //        .ThenInclude(um => um.Movie)
        //        .ThenInclude(m => m.Genre)
        //        .FirstOrDefaultAsync();

        //    if (user == null)
        //    {
        //        throw new ArgumentException("Invalid user ID");
        //    }

        //    return user.UsersMovies
        //        .Select(m => new MovieViewModel()
        //        {
        //            Director = m.Movie.Director,
        //            Genre = m.Movie.Genre?.Name,
        //            Id = m.MovieId,
        //            ImageUrl = m.Movie.ImageUrl,
        //            Title = m.Movie.Title,
        //            Rating = m.Movie.Rating,
        //        });
        //}

        //public async Task RemoveMovieFromCollectionAsync(int movieId, string userId)
        //{
        //    var user = await context.Users
        //        .Where(u => u.Id == userId)
        //        .Include(u => u.UsersMovies)
        //        .FirstOrDefaultAsync();

        //    if (user == null)
        //    {
        //        throw new ArgumentException("Invalid user ID");
        //    }

        //    var movie = user.UsersMovies.FirstOrDefault(m => m.MovieId == movieId);

        //    if (movie != null)
        //    {
        //        user.UsersMovies.Remove(movie);

        //        await context.SaveChangesAsync();
        //    }
        //}
    }
}
