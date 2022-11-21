using FinancialServices.Areas.Administration.Models;
using FinancialServices.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FinancialServices.Areas.Administration.Controllers
{
    public class AdministrationController : Controller
    {


        private readonly IDatabaseService databaseService;

        public AdministrationController(IDatabaseService _databaseService)
        {
            databaseService = _databaseService;
        }


        [HttpGet]
        [Area("Administration")]
        public IActionResult Index()
        {
            //if (User?.Identity?.IsAuthenticated ?? false)
            //{
            //    return RedirectToAction("All", "Movies");
            //}

            // await databaseService.ImportsEntities();

            var model = new ImportsViewModel();

            return View(model);
        }



       
        public async Task<IActionResult> Import()
        {

         
            await databaseService.ImportsEntities();

            return RedirectToAction("Index", "Home");
        }

      
    }
}


