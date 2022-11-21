using FinancialServices.Data;
using Microsoft.AspNetCore.Mvc;
using FinancialServices.Contracts;
using FinancialServices.Constants;

namespace FinancialServices.Controllers
{


    public class HomeController : Controller
    {
       
        private readonly IDatabaseService databaseService;

        public HomeController( IDatabaseService _databaseService)
        {        
            databaseService = _databaseService;
        }



        public  IActionResult Index()
        {
           

            //if (User?.Identity?.IsAuthenticated ?? false)
            //{
            //    return RedirectToAction("All", "Movies");
            //}


            //await databaseService.ImportsEntities();

            return View();
        }
    }
}