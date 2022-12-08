using FinancialServices.Constants;
using FinancialServices.Contracts;
using FinancialServices.Models;
using FinancialServices.Models.Persons;
using FinancialServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialServices.Controllers
{
    [Authorize]
    public class OwnerCompanyController : Controller
    {

        private readonly IOwnerCompanyService ownerCompanyervice;

        private readonly ICompanyService companyService;

        public OwnerCompanyController(
            IOwnerCompanyService _ownerCompanyervice,
           ICompanyService _companyService)
        {
            ownerCompanyervice = _ownerCompanyervice;
            companyService = _companyService;

        }


        [HttpGet]
        public async Task<IActionResult> Add(long idEik)
        {
            var model = new AddOwnerCompanyViewModel();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(long idEik, AddOwnerCompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await companyService.isCompanyExist(model.OwnerEik) == true)
            {
                try
                {
                    await ownerCompanyervice.AddOwnerAsync(idEik, model);

                    TempData[MessageConstants.SiccessMessage] = "Успешно добавихте собственик Ю.Л. от фирмата ви";

                    return RedirectToAction("Details", "Company", new { idEik = idEik });
                }
                catch (Exception)
                {
                    TempData[MessageConstants.WarningMessage] = "Вече сте добавили Ю.Л. във фирмата";

                    return View(model);
                }
              
            }
            else
            {
                TempData[MessageConstants.WarningMessage] = "Няма фирма с такова ЕИК в базата";

                return View(model);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Delete(long idEik)
        {
            var model = new AddOwnerCompanyViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long idEik, AddOwnerCompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {

                TempData[MessageConstants.WarningMessage] = "Модела е невалиден";

                return View(model);
            }

            if (await companyService.isCompanyExist(model.OwnerEik) == true)
            {
                await ownerCompanyervice.DeleteAsync(idEik, model.OwnerEik);

                TempData[MessageConstants.SiccessMessage] = "Успешно изтрихте собственик Ю.Л. от фирмата ви";

                return RedirectToAction("Details", "Company", new { idEik = idEik });
            }
            else
            {
                TempData[MessageConstants.WarningMessage] = "Няма фирма с такова ЕИК в базата";

                return View(model);
            }

           


        }
    }
}

