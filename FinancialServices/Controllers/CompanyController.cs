using FinancialServices.Contracts;
using FinancialServices.Data;
using FinancialServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Theatre.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinancialServices.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;
     


        public CompanyController(ICompanyService _movieService)
        {
            companyService = _movieService;
          
        }
         

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await companyService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddCompaniesViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCompaniesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await companyService.AddCompanyAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }


        public async Task<IActionResult> Edit(long idEik)
        {

            var company = await companyService.GetCompanyAsync(idEik);

            AddCompaniesViewModel model = new AddCompaniesViewModel
            {
                IdEik = company.IdEik,
                CompanyName = company.CompanyName,
                AddressCompany = company.AddressCompany,
                AddressActivity = company.AddressActivity,
                KidNumber = company.KidNumber,
                Representing = company.Representing,
                TypeRepresenting = company.TypeRepresenting,
                TypeCompany = company.TypeCompany,
                ContactName = company.ContactName,
                PhoneNumber = company.PhoneNumber,
                Email = company.Email,
                Status = company.Status,
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(long idEik, AddCompaniesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {            
                await companyService.EditCompanyAsync(idEik, model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }


        public async Task<IActionResult> CompanyInfo(long idEik)
        {
            var company = await companyService.GetCompanyAsync(idEik);

           List<Person> managers = await companyService.GetManagersAsync(idEik);

           List<MapingOwnerCompany> mapingOwnerCompanys = await companyService.GetCompanyOwnersDataAsync(idEik);

            List<Company> ownersCompanys =  await companyService.GetCompanyOwnersAsync(mapingOwnerCompanys);

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
                OwnersPersons=company.MapingOwnerPersons.Select(x=>x.Person).ToList<Person>(),
                OwnersCompaniesData = mapingOwnerCompanys,
                OwnersCompanies= ownersCompanys

            };


            return View(model);
        }


        [HttpPost]
        public async Task< IActionResult> Delete(long idEik)
        {
           await companyService.DeleteAsync(idEik);

            return RedirectToAction(nameof(All));
        }


        [HttpPost]
        public async Task<IActionResult> Deactivate(long idEik)
        {
            await companyService.DeactivateAsync(idEik);

            return RedirectToAction(nameof(All));
        }

    }

    //public async Task<IActionResult> AddToCollection(int movieId)
    //{
    //    try
    //    {
    //        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    //        await movieService.AddMovieToCollectionAsync(movieId, userId);
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }

    //    return RedirectToAction(nameof(All));
    //}

    //public async Task<IActionResult> Watched()
    //{
    //    var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    //    var model = await movieService.GetWatchedAsync(userId);

    //    return View("Mine", model);
    //}

    //public async Task<IActionResult> RemoveFromCollection(int movieId)
    //{
    //    var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    //    await movieService.RemoveMovieFromCollectionAsync(movieId, userId);

    //    return RedirectToAction(nameof(Watched));
    //}}
}

