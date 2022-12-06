using FinancialServices.Constants;
using FinancialServices.Contracts;
using FinancialServices.Models;
using FinancialServices.Models.Persons;
using Microsoft.AspNetCore.Mvc;

namespace FinancialServices.Controllers
{
    public class ManagerController : Controller
    {

        private readonly IManagerService managerService;

        private readonly IPersonService personService;

        public ManagerController(
            IManagerService _managerService,
            IPersonService _personService)
        {
            managerService = _managerService;
            personService = _personService;

        }


        [HttpGet]
        public async Task<IActionResult> Add(long idEik)
        {
            var model = new AddManagerViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(long idEik, AddManagerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            if (await personService.isPersonExist(model.IdEgn))
            {
                try
                {
                    await managerService.AddManagerAsync(idEik, model);

                    TempData[MessageConstants.SiccessMessage] = "Успешно добавихте мениджър";

                    return RedirectToAction("Details", "Company", new { idEik = idEik });
                }
                catch (Exception)
                {

                    TempData[MessageConstants.WarningMessage] = "Вече сте добавичи Ф.Л. във фирмата";

                    return View(model);

                }
               

            }
            else
            {
                TempData[MessageConstants.WarningMessage] = "Няма мениджър с такова ЕГН";

                return View(model);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Delete(long idEik)
        {
            var model = new AddManagerViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long idEik, AddManagerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await personService.isPersonExist(model.IdEgn) == true)
            {
                await managerService.DeleteAsync(idEik, model.IdEgn);

                TempData[MessageConstants.SiccessMessage] = "Успешно изтрихте мениджър";

                return RedirectToAction("Details", "Company", new { idEik = idEik });
            }
            else
            {
                TempData[MessageConstants.WarningMessage] = "Няма човек стакова егн";

                return View(model);
            }

        }

    }
}
