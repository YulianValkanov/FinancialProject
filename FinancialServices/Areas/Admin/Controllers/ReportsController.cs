using FinancialServices.Areas.Administration.Controllers;
using FinancialServices.Areas.Administration.Models;
using FinancialServices.Constants;
using FinancialServices.Contracts;
using FinancialServices.Models;
using FinancialServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialServices.Areas.Admin.Controllers
{
    public class ReportsController : BaseController
    {

        private readonly IDatabaseService databaseService;

        public ReportsController(IDatabaseService _databaseService)
        {
            databaseService = _databaseService;
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ImportReportViewModel();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ImportReportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

       
            {
                try
                {
                    await databaseService.ImportOpr(model.IdEik, model.CompanyName, model.YearReport);

                    TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";

                }
                catch (Exception)
                {
                    TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                    ModelState.AddModelError("", "Something went wrong");

                }
                return RedirectToAction("DetailsPnl", "Report", new { idEik = model.IdEik });

            }


        }
    }
}
