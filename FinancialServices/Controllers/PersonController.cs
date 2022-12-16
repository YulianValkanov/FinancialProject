using FinancialServices.Constants;
using FinancialServices.Contracts;
using FinancialServices.Models.Companies;
using FinancialServices.Models.Persons;
using FinancialServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static FinancialServices.Areas.Administration.Constants.AdminConstants;

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
        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Add()
        {
            var model = new AddPersonViewModel();


            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRolleName)]
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

                return RedirectToAction("All", "Person");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                TempData[MessageConstants.ErrorMessage] = "Такъв човек вече съществува в базата данни";

                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllQuaryPersonViewModel query)
        {
            var pers = await personService.AllFilter(
                query.IdEgn.ToString(),
                query.FirstName,
                query.LastName              
                );

            query.Persons = pers;

            return View(query);
        }


        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Edit(long idEgn)
        {
            var person = await personService.GetPersonAsync(idEgn);

            AddPersonViewModel model = new AddPersonViewModel
            {
                IdEgn = person.IdEgn,
                FirstName = person.FirstName,
                SecondName=person.SecondName,
                LastName=person.LastName

            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Edit(long idEgn, AddPersonViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await personService.EditPersonAsync(idEgn, model);

                TempData[MessageConstants.SiccessMessage] = "Успешно редактирахте лицето";

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong with editing");

                return View(model);
            }
        }


        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Delete(long idEgn)
        {
            await personService.DeleteAsync(idEgn);

            TempData[MessageConstants.ErrorMessage] = "Успешно изтрихте физическо лице";

            return RedirectToAction(nameof(All));
        }



    }
}
