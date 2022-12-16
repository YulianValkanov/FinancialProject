using FinancialServices.Constants;
using FinancialServices.Contracts;
using FinancialServices.Models.Credits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static FinancialServices.Areas.Administration.Constants.AdminConstants;

namespace FinancialServices.Controllers
{
    [Authorize]
    public class CreditController : Controller
    {
        private readonly ICreditService creditService;
    

        public CreditController(
            ICreditService _creditService

            )
        {

            creditService= _creditService;
        

        }



        public async Task< IActionResult> Details(long idEik)
        {

            var model = await creditService.GetAllAsync(idEik);


            return View(model);
        }


        [HttpGet]
        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Add()
        {
            var model = new AddCreditViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Add(long idEik, AddCreditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await creditService.isCreditExist(idEik, model.CreditNumber) == false)
            {
                try
                {
                    await creditService.AddCreditAsync(idEik, model);

                    TempData[MessageConstants.SiccessMessage] = "Успешно добавихте кредит";

                    return RedirectToAction("Details", "Credit", new { idEik = idEik });
                }
                catch (Exception)
                {

                    TempData[MessageConstants.WarningMessage] = "Вече сте добавили кредита";

                    return View(model);
                }


            }
            else
            {
                TempData[MessageConstants.WarningMessage] = "Вече има добавен кредит с този номер";

                return View(model);
            }
        }

        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Delete(long idEik, int CreditNumber)
        {
            await creditService.DeleteAsync(idEik, CreditNumber);

            TempData[MessageConstants.WarningMessage] = "Успешно изтрихте кредит";

            return RedirectToAction("Details", "Credit", new { idEik = idEik });
        }


        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Edit(long idEik, int CreditNumber)
        {
            var credit = await creditService.GetCreditAsync(idEik, CreditNumber);

            CreditViewModel model = new CreditViewModel
            {               
                CreditId= credit.CreditId,
                IdEik = credit.IdEik,
                BeginValue = credit.BeginValue,
                Rate = credit.Rate,
                PresentValue = credit.PresentValue

            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRolleName)]
        public async Task<IActionResult> Edit(long idEik, CreditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await creditService.EditCreditAsync(idEik, model);

                TempData[MessageConstants.SiccessMessage] = "Успешно редактирахте кредита";

                return RedirectToAction("Details", "Credit", new { idEik = idEik });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong with editing");

                return View(model);
            }
        }
    }
}
