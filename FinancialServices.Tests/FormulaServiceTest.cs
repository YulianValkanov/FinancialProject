using FinancialServices.Contracts;
using FinancialServices.Data.Common;
using FinancialServices.Data;
using FinancialServices.Data.Models;
using FinancialServices.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialServices.Tests
{

    public class FormulaServiceTest
    {

        [TestFixture]
        public class CompanyServiceTests
        {

            private IFormulasService forulaService;


            [SetUp]
            public void Setup()
            {


            }

            [Test]
            public async Task TestGetMSPpersonsBig()
            {
                forulaService = new FormulasService();

                int personal = 250;
                double revenues = 1;
                double assets = 1;

               var result= forulaService.GetMsp(personal, revenues, assets);

                Assert.That(result, Is.EqualTo("ГОЛЯМО"));
            }

            [Test]
            public async Task TestGetMSPpersonsMiddle()
            {
                forulaService = new FormulasService();

                int personal = 249;
                double revenues = 1;
                double assets = 1;

                var result = forulaService.GetMsp(personal, revenues, assets);

                Assert.That(result, Is.EqualTo("СРЕДНО"));
            }
            [Test]
            public async Task TestGetMSPpersonsSmall()
            {
                forulaService = new FormulasService();

                int personal = 49;
                double revenues = 1;
                double assets = 1;

                var result = forulaService.GetMsp(personal, revenues, assets);

                Assert.That(result, Is.EqualTo("МАЛКО"));
            }

            [Test]
            public async Task TestGetMSPpersonsMicro()
            {
                forulaService = new FormulasService();

                int personal = 9;
                double revenues = 1;
                double assets = 1;

                var result = forulaService.GetMsp(personal, revenues, assets);

                Assert.That(result, Is.EqualTo("МИКРО"));
            }

            [Test]
            public async Task TestGetMSPssetsAndRevenuesBig()
            {
                forulaService = new FormulasService();

                int personal = 1;
                double revenues = 98000000;
                double assets = 98000000;

                var result = forulaService.GetMsp(personal, revenues, assets);

                Assert.That(result, Is.EqualTo("ГОЛЯМО"));
            }

            [Test]
            public async Task TestGetMSPssetsAndRevenuesМиддле()
            {
                forulaService = new FormulasService();

                int personal = 1;
                double revenues = 20000000;
                double assets = 20000000;

                var result = forulaService.GetMsp(personal, revenues, assets);

                Assert.That(result, Is.EqualTo("СРЕДНО"));
            }

            [Test]
            public async Task TestGetMSPssetsAndRevenuesSmall()
            {
                forulaService = new FormulasService();

                int personal = 1;
                double revenues = 4000000;
                double assets = 4000000;

                var result = forulaService.GetMsp(personal, revenues, assets);

                Assert.That(result, Is.EqualTo("МАЛКО"));

            }


            [Test]
            public async Task TestGetMSPssetsAndRevenuesMicro()
            {
                forulaService = new FormulasService();

                int personal = 1;
                double revenues = 3000000;
                double assets = 3000000;

                var result = forulaService.GetMsp(personal, revenues, assets);

                Assert.That(result, Is.EqualTo("МИКРО"));

            }

         

          


        }

    }
}
