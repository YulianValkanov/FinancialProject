﻿using FinancialServices.Areas.Administration.Models;
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

            var model = new ImportsViewModel();

            return View(model);
        }



       
        public async Task<IActionResult> Import()
        {       
           
            try
            {
                await databaseService.ImportsEntities();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");

                return RedirectToAction(nameof(Index));
            }
        }

        
        public async Task<IActionResult> ImportKid()
        {           
            try
            {
                await databaseService.ImportKid();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");

                return RedirectToAction(nameof(Index));
            }
  
        }



        public async Task<IActionResult> ImportPersons()
        {          
            try
            {
                await databaseService.ImportPersons();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");

                return RedirectToAction(nameof(Index));
            }
        }


        public async Task<IActionResult> ImportCompanies()
        {
           
            try
            {
                await databaseService.ImportCompanies();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");

                return RedirectToAction(nameof(Index));
            }
        }


        public async Task<IActionResult> ImportManagers()
        {
           
            try
            {
                await databaseService.ImportManagers();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");

                return RedirectToAction(nameof(Index));
            }
        }


        public async Task<IActionResult> ImportOwnerPersons()
        {
           
            try
            {
                await databaseService.ImportOwnerPersons();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");

                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> ImportOwnerCompany()
        {
           
            try
            {
                await databaseService.ImportOwnerCompany();

                TempData[MessageConstants.SiccessMessage] = "Успешно импортиране";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно импортиране";

                ModelState.AddModelError("", "Something went wrong");

                return RedirectToAction(nameof(Index));
            }
        }




    }
}

