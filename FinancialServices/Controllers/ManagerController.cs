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



        public ManagerController(IManagerService _managerService)
        {
            managerService = _managerService;

        }



        [HttpGet]
        public async Task<IActionResult> Add(long idEik)
        {
            var model = new AddManagerViewModel();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(long idEik,AddManagerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await managerService.AddManagerAsync( idEik,model);

                TempData[MessageConstants.SiccessMessage] = "Успешно добавихте мениджър";

                return RedirectToAction("All", "Company");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                TempData[MessageConstants.WarningMessage] = "Липсва мениджър с това ЕГН във базата";

                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(long idEik)
        {
            var model = new AddManagerViewModel();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long idEik, AddManagerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await managerService.DeleteAsync(idEik, model.IdEgn);

                TempData[MessageConstants.SiccessMessage] = "Успешно изтрихте мениджър";

             

                 return RedirectToAction("All", "Company");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                TempData[MessageConstants.WarningMessage] = "Липсва мениджър с това ЕГН във базата";

                return View(model);
            }
        }

    }
}
