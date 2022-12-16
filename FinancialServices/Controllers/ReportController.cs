using FinancialServices.Constants;
using FinancialServices.Contracts;
using FinancialServices.Models.Companies;
using FinancialServices.Models.Persons;
using FinancialServices.Models.Reports;
using FinancialServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FinancialServices.Areas.Administration.Constants.AdminConstants;

namespace FinancialServices.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IReportService reportService;
    

        public ReportController(
            IReportService _reportService
         
            )
        {

            reportService= _reportService;
        

        }



        public async Task< IActionResult> Details(long idEik)
        {

            var model = await reportService.GetAllAsync(idEik);


            return View(model);
        }


        [HttpGet]
        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Add()
        {
            var model = new AddReportViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Add(long idEik, AddReportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await reportService.isReportExist(idEik, model.YearReport) == false)
            {
                try
                {
                    await reportService.AddReportAsync(idEik, model);

                    TempData[MessageConstants.SiccessMessage] = "Успешно добавихте отчет";

                    return RedirectToAction("Details", "Report", new { idEik = idEik });
                }
                catch (Exception)
                {

                    TempData[MessageConstants.WarningMessage] = "Вече сте добавили отчет";

                    return View(model);
                }


            }
            else
            {
                TempData[MessageConstants.WarningMessage] = "Вече има добавен отчет за тази година";

                return View(model);
            }
        }

        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Delete(long idEik, int YearReport)
        {
            await reportService.DeleteAsync(idEik, YearReport);

            TempData[MessageConstants.WarningMessage] = "Успешно изтрихте отчет";

            return RedirectToAction("Details", "Report", new { idEik = idEik });
        }


        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Edit(long idEik, int yearReport)
        {
            var report = await reportService.GetReportAsync(idEik, yearReport);

            ReportViewModel model = new ReportViewModel
            {
                ReportId=report.ReportId,
                IdEik = report.IdEik,
                Assets=report.Assets,
                AnnualTurnover=report.AnnualTurnover,
                CountOfEmployees=report.CountOfEmployees
                
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Edit(long idEik, ReportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await reportService.EditReportAsync(idEik, model);

                TempData[MessageConstants.SiccessMessage] = "Успешно редактирахте отчет";

                return RedirectToAction("Details", "Report", new { idEik = idEik });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong with editing");

                return View(model);
            }
        }
    }
}
