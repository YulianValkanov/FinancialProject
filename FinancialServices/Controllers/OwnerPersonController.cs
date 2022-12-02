using FinancialServices.Constants;
using FinancialServices.Contracts;
using FinancialServices.Models;
using FinancialServices.Models.Persons;
using Microsoft.AspNetCore.Mvc;

namespace FinancialServices.Controllers
{
    public class OwnerPersonController : Controller
    {

        private readonly IOwnerPersonService managerService;

        public OwnerPersonController(IOwnerPersonService _managerService)
        {
            managerService = _managerService;

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

            try
            {
                await managerService.AddOwnerAsync( idEik,model);

                TempData[MessageConstants.SiccessMessage] = "Успешно добавихте soсобственик Ф.Л.";

                return RedirectToAction("Details","Company", new { idEik = idEik });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

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

            try
            {
                await managerService.DeleteAsync(idEik, model.IdEgn);

                TempData[MessageConstants.SiccessMessage] = "Успешно изтрихте собственик Ф.Л.";



                return RedirectToAction("Details", "Company", new { idEik = idEik });
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
