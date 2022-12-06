using FinancialServices.Constants;
using FinancialServices.Contracts;
using FinancialServices.Models;
using FinancialServices.Models.Persons;
using FinancialServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialServices.Controllers
{
    public class OwnerPersonController : Controller
    {

        private readonly IOwnerPersonService managerService;

        private readonly IPersonService personService;

        public OwnerPersonController(
            IOwnerPersonService _managerService,
            IPersonService _personService)
        {
            managerService = _managerService;
            personService = _personService;

        }

        [HttpGet]
        public async Task<IActionResult> Add(long idEik)
        {
            var model = new AddOwnerPersonViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(long idEik, AddOwnerPersonViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await personService.isPersonExist(model.IdEgn) == true)
            {
                try
                {
                    await managerService.AddOwnerAsync(idEik, model);

                    TempData[MessageConstants.SiccessMessage] = "Успешно добавихте soсобственик Ф.Л.";

                    return RedirectToAction("Details", "Company", new { idEik = idEik });
                }
                catch (Exception)
                {

                   TempData[MessageConstants.WarningMessage] = "Вече сте добавили Ф.Л. във фирмата";

                    return View(model);
                }
               

            }
            else
            {
                TempData[MessageConstants.WarningMessage] = "Липсва собственик Ф.Л. с това ЕГН във базата";

                return View(model);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Delete(long idEik)
        {
            var model = new AddOwnerPersonViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long idEik, AddOwnerPersonViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstants.WarningMessage] = "Модела е невалиден";

                return View(model);
            }

            if (await personService.isPersonExist(model.IdEgn) == true)
            {
                await managerService.DeleteAsync(idEik, model.IdEgn);

                TempData[MessageConstants.SiccessMessage] = "Успешно изтрихте собственик";

                return RedirectToAction("Details", "Company", new { idEik = idEik });
            }
            else
            {
                TempData[MessageConstants.WarningMessage] = "Няма човек с такова егн";

                return View(model);
            }
 
        }

    }

}

