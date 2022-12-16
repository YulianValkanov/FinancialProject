using FinancialServices.Constants;
using FinancialServices.Contracts;
using FinancialServices.Models.Companies;
using FinancialServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FinancialServices.Areas.Administration.Constants.AdminConstants;


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
        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Add()
        {
            var model = new AddCompaniesViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Add(AddCompaniesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await companyService.AddCompanyAsync(model);

                TempData[MessageConstants.SiccessMessage] = "Успешно добавихте фирма";

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong with Adding company");

                return View(model);
            }
        }

        [Authorize(Roles = AdminRolleName)]
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
        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Edit(long idEik, AddCompaniesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await companyService.EditCompanyAsync(idEik, model);

                TempData[MessageConstants.SiccessMessage] = "Успешно редактирахте фирма";

                return RedirectToAction(nameof(Details), new { idEik = model.IdEik });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong with editing");

                return View(model);
            }
        }
      
        public async Task<IActionResult> Details(long idEik)
        
        {
           var company= await companyService.GetCompanyAsync(idEik);

            if (company == null)
            {
                TempData[MessageConstants.WarningMessage] = "Няма фирма с такова ЕИК";

                return RedirectToAction(nameof(All));

            }

            var model = await companyService.CompanyDetailsById(idEik);
          
            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = AdminRolleName)]
        public async Task< IActionResult> Delete(long idEik)
        {
           await companyService.DeleteAsync(idEik);

            TempData[MessageConstants.ErrorMessage] = "Успешно изтрихте фирма";

            return RedirectToAction(nameof(All));
        }


        [HttpPost]
        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Deactivate(long idEik)
        {
            await companyService.DeactivateAsync(idEik);

            TempData[MessageConstants.WarningMessage] = "Успешно деактивирахте фирма";

            return RedirectToAction(nameof(Details), new { idEik = idEik });
        }


        [HttpGet]    
        public async Task<IActionResult> All([FromQuery] AllQueryModel query)
        {
            var comp = await companyService.AllFilter(
                query.Eik.ToString(),
                query.CompanyName,
                query.Kid,
                query.Group
                );
         
            query.Companyes = comp;

            return View(query);
        }

    }


}

