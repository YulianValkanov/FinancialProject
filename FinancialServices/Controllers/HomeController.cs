using FinancialServices.Data;
using Microsoft.AspNetCore.Mvc;
using FinancialServices.Contracts;
using FinancialServices.Constants;
using FinancialServices.Models.Home;
using FinancialServices.Models.Companies;
using FinancialServices.Services;

namespace FinancialServices.Controllers
{


    public class HomeController : Controller
    {
        private readonly IFormulasService formulaService;

        public HomeController(IFormulasService _formulaService)
        {

           formulaService = _formulaService;

        }

        public  IActionResult Index()
        {
           
            return View();
        }

       


        [HttpGet]
        public IActionResult Calculator([FromQuery] CalculatorQueryModel query)
        {
            if (!ModelState.IsValid)
            {
                return View(query);
            }

            query.Pmt = formulaService.GetPmt(query.Rate,query.Periods, query.Amount);

            return View(query);
        }

        [HttpGet]
        public IActionResult Msp([FromQuery] MspQueryModel query)
        {
           

            string status = formulaService.GetMsp(query.Personal, query.Assets, query.Revenue);

            query.Msp = status;

            return View(query);
        }

    }
}