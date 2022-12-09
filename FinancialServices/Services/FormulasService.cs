using FinancialServices.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;
using Theatre.Data.Models;

namespace FinancialServices.Services
{
    public class FormulasService : IFormulasService
    {

        public double GetPmt(double ir, int np, double pv)
        {
            /*
           * ir   - interest rate per month
           * np   - number of periods (months)
           * pv   - present value
           * fv   - future value
           * type - when the payments are due:
           *        0: end of the period, e.g. end of month (default)
           *        1: beginning of period
           */

            double pmt = 0;
            double pvif = 0;
          

            if ((ir / 12) / 100 == 0)
            {
                return -(pv) / np;
            }

            pvif = Math.Pow(1 + (ir / 12) / 100, np);

            pmt = (ir / 12) / 100 * (pv * pvif) / (pvif - 1);

            return pmt;       
        }


        public string FormatThisNumber(double number)
        {

            var nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();

            nfi.NumberGroupSeparator = " ";

            return  number.ToString("#,0.00", nfi); // "1 234 897.11"

        }

       


    }
}
