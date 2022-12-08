using FinancialServices.Data;
using Microsoft.AspNetCore.Mvc;
using FinancialServices.Contracts;
using FinancialServices.Constants;

namespace FinancialServices.Controllers
{


    public class HomeController : Controller
    {
       
      
        public  IActionResult Index()
        {
           
            return View();
        }



    }
}