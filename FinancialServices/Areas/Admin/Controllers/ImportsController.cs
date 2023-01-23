using FinancialServices.Areas.Administration.Models;
using FinancialServices.Constants;
using FinancialServices.Contracts;
using FinancialServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinancialServices.Areas.Administration.Controllers
{


    public class ImportsController : BaseController
    {


        private readonly IDatabaseService databaseService;

        public ImportsController(IDatabaseService _databaseService)
        {
            databaseService = _databaseService;
        }

        [HttpGet]

        public IActionResult Index()
        {
            //if (User?.Identity?.IsAuthenticated ?? false)
            //{
            //    return RedirectToAction("All", "Movies");
            //}

            // await databaseService.ImportsEntities();

            var model = new ImportReportViewModel();

            return View(model);
        }




        public async Task<IActionResult> Import()
        {

            try
            {
                await databaseService.ImportsEntities();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";

            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");

            }
            return RedirectToAction(nameof(Index), "Admin");

        }


        public async Task<IActionResult> ImportKid()
        {
            try
            {
                await databaseService.ImportKid();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";

            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");

            }

            return RedirectToAction(nameof(Index), "Admin");

        }



        public async Task<IActionResult> ImportPersons()
        {
            try
            {
                await databaseService.ImportPersons();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";


            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");


            }

            return RedirectToAction(nameof(Index), "Admin");
        }


        public async Task<IActionResult> ImportCompanies()
        {

            try
            {
                await databaseService.ImportCompanies();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";
         
            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");


            }

            return RedirectToAction(nameof(Index), "Admin");
        }


        public async Task<IActionResult> ImportManagers()
        {

            try
            {
                await databaseService.ImportManagers();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";


            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");


            }

            return RedirectToAction(nameof(Index), "Admin");
        }


        public async Task<IActionResult> ImportOwnerPersons()
        {

            try
            {
                await databaseService.ImportOwnerPersons();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";


            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");


            }

            return RedirectToAction(nameof(Index), "Admin");
        }

        public async Task<IActionResult> ImportOwnerCompany()
        {

            try
            {
                await databaseService.ImportOwnerCompany();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";


            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");


            }

            return RedirectToAction(nameof(Index), "Admin");
        }


        public async Task<IActionResult> ImportReports()
        {

            try
            {
                await databaseService.ImportReports();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";
                
            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");


            }

            return RedirectToAction(nameof(Index), "Admin");
        }

        public async Task<IActionResult> ImportReportsMaping()
        {

            try
            {
                await databaseService.ImportReportsMaping();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране на мапваща таблица с репорти";

            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране на мапваща таблица с репорти";

                ModelState.AddModelError("", "Something went wrong");


            }

            return RedirectToAction(nameof(Index), "Admin");
        }




    }
}


