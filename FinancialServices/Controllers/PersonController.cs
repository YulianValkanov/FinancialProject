using FinancialServices.Constants;
using FinancialServices.Contracts;
using FinancialServices.Models.Persons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialServices.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {

        private readonly IPersonService personService;

        public PersonController(IPersonService _personService)
        {
            personService = _personService;

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddPersonViewModel();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPersonViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await personService.AddPersonAsync(model);

                TempData[MessageConstants.SiccessMessage] = "Успешно добавихте човек";

                return RedirectToAction("All", "Company");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                TempData[MessageConstants.ErrorMessage] = "Такъв човек вече съществува в базата данни";

                return View(model);
            }
        }





    }
}
