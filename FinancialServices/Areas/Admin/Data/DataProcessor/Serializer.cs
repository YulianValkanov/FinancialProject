namespace FinancialServices.Areas.Administration.Data.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using Theatre.Data;

    public class Serializer
    {
        //    public static string ExportTheatres(IveniConsultContext context, int numbersOfHalls)
        //    {

        //        var theatres = context.Theatres
        //            .ToArray()
        //            .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
        //            .Select(t => new
        //            {
        //                Name = t.Name,
        //                Halls = t.NumberOfHalls,
        //                TotalIncome =t.Tickets.Where(x => x.RowNumber <= 5).Sum(s => s.Price),
        //                Tickets = t.Tickets
        //                .Where(x => x.RowNumber <= 5)
        //                  .OrderByDescending(x => x.Price)
        //                .Select(t => new
        //                {
        //                    Price = t.Price,
        //                    RowNumber = t.RowNumber
        //                }).ToArray()










        //            })
        //            .ToArray()
        //            .OrderByDescending(x => x.Halls)
        //            .ThenBy(x => x.Name);

        //        string json = JsonConvert.SerializeObject(theatres, Formatting.Indented);

        //        return json;



        //        //        "Name": "Capitol Theatre Building",
        //        //"Halls": 10,
        //        //"TotalIncome": 860.02,
        //        //"Tickets": [
        //        //  {
        //        //    "Price": 93.48,
        //        //    "RowNumber": 3
        //        //  },
        //        //  {
        //        //    "Price": 93.41,
        //        //    "RowNumber": 1
        //        //  },

        //    }

        //    public static string ExportPlays(IveniConsultContext context, double rating)
        //    {
        //        throw new NotImplementedException();
        //    }
    }
}
