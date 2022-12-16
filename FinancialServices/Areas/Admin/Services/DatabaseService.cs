using FinancialServices.Contracts;
using FinancialServices.Data;


namespace FinancialServices.Areas.Administration.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly FinanceDbContext context;

        string baseDir = "../FinancialServices/Areas/Admin/Data/Datasets/";

        public DatabaseService(FinanceDbContext _context)
        {
            context = _context;
        }

        public async Task ImportKid()
        {
            Data.DataProcessor.Deserializer.ImportKids(context,
                   File.ReadAllText(baseDir + "KID_2008.json"));
        }

        public async Task ImportPersons()
        {
            Data.DataProcessor.Deserializer.ImportPersons(context,
                    File.ReadAllText(baseDir + "Persons.json"));
        }

        public async Task ImportCompanies()
        {
            Data.DataProcessor.Deserializer.ImportCompanies(context,
             File.ReadAllText(baseDir + "Companies.json"));
        }


        public async  Task ImportManagers()
        {    

            Data.DataProcessor.Deserializer.ImportManagers(context,
          File.ReadAllText(baseDir + "Managers.json"));
        }

        public async Task ImportOwnerPersons()
        {
            Data.DataProcessor.Deserializer.ImportOwnerPerson(context,
            File.ReadAllText(baseDir + "PersonsOwners.json"));
        }

        public async Task ImportOwnerCompany()
        {
            Data.DataProcessor.Deserializer.ImportOwnerCompany(context,
           File.ReadAllText(baseDir + "CompayesOwner.json"));
        }

        public async Task ImportReports()
        {
            Data.DataProcessor.Deserializer.ImportReports(context,
           File.ReadAllText(baseDir + "Reports.json"));
        }

        public async Task ImportReportsMaping()
        {
            Data.DataProcessor.Deserializer.ImportReportsMaping(context,
           File.ReadAllText(baseDir + "ReportsMaping.json"));
        }




        // ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");

        //  ExportEntities(context, projectDir + @"ExportResults/");

        //    using (var transaction = context.Database.BeginTransaction())
        //    {
        //        transaction.Rollback();
        //    }
        //}

        //private static void ImportEntities(FinancialServicesDbContext context)      /////not using this methood
        //{

        //string baseDir = "../../../Data/Datasets";


        //Data.DataProcessor.Deserializer.ImportKids(context,
        //     File.ReadAllText(baseDir + "KID_2008.json"));


        //    var persons =
        //        Data.DataProcessor.Deserializer.ImportPersons(context,
        //            File.ReadAllText(baseDir + "Persons.json"));


        //    var companies =
        //Data.DataProcessor.Deserializer.ImportCompanies(context,
        //  File.ReadAllText(baseDir + "Companies.json"));


        //    var mapingManagers =
        // Data.DataProcessor.Deserializer.ImportManagers(context,
        //File.ReadAllText(baseDir + "Managers.json"));


        //    var mapingOwnerPerson =
        //Data.DataProcessor.Deserializer.ImportOwnerPerson(context,
        //File.ReadAllText(baseDir + "PersonsOwners.json"));



        //    var mapingOwnerCompany =
        //Data.DataProcessor.Deserializer.ImportOwnerCompany(context,
        //File.ReadAllText(baseDir + "CompayesOwner.json"));


        //}

        public async Task ImportsEntities()
        {

            Data.DataProcessor.Deserializer.ImportKids(context,
                   File.ReadAllText(baseDir + "KID_2008.json"));

            Data.DataProcessor.Deserializer.ImportPersons(context,
                    File.ReadAllText(baseDir + "Persons.json"));

            Data.DataProcessor.Deserializer.ImportCompanies(context,
              File.ReadAllText(baseDir + "Companies.json"));

            Data.DataProcessor.Deserializer.ImportManagers(context,
           File.ReadAllText(baseDir + "Managers.json"));

            Data.DataProcessor.Deserializer.ImportOwnerPerson(context,
            File.ReadAllText(baseDir + "PersonsOwners.json"));

            Data.DataProcessor.Deserializer.ImportOwnerCompany(context,
            File.ReadAllText(baseDir + "CompayesOwner.json"));

        }

      
    }
}
