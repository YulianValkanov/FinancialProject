namespace FinancialServices.Areas.Administration.Data.DataProcessor
{
    using FinancialServices.Areas.Admin.Data.DataProcessor.ImportDto;
    using FinancialServices.Areas.Administration.Data.DataProcessor.ImportDto;
    using FinancialServices.Data;
    using FinancialServices.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Theatre.Data.Models;

    public class Deserializer
    {


        public static string ImportKids(FinanceDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportKidDto[] kidDto = JsonConvert.DeserializeObject<ImportKidDto[]>(jsonString);

            HashSet<Kid> validKids = new HashSet<Kid>();

            foreach (var kid in kidDto)
            {


                if (!IsValid(kid))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }


                Kid currentKid = new Kid()
                {

                    KidNumber = kid.KIDnumber,
                    Group = kid.Group,
                    GroupName = kid.GroupName,
                    PositionName = kid.PositionName
                };

               

                validKids.Add(currentKid);



                sb.AppendLine($"Successfully imported kidNumber {currentKid.KidNumber} - {currentKid.GroupName} - {currentKid.PositionName}");
            }

            context.AddRange(validKids);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string ImportPersons(FinanceDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPersonsDto[] personDto = JsonConvert.DeserializeObject<ImportPersonsDto[]>(jsonString);

            HashSet<Person> validPersons = new HashSet<Person>();

            foreach (var person in personDto)
            {


                if (!IsValid(person))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Person isPeopleInValid = validPersons.FirstOrDefault(x => x.IdEgn == person.IdEgn);

                if (isPeopleInValid != null)
                {
                    sb.AppendLine("Person with same EGN");
                    continue;
                }


                Person currentPerson = new Person()
                {
                    IdEgn = person.IdEgn,
                    FirstName = person.FirstName,
                    SecondName = person.SecondName,
                    LastName = person.LastName
                };

             

                validPersons.Add(currentPerson);



                sb.AppendLine($"Successfully imported  {currentPerson.FirstName} with ENG {currentPerson.IdEgn}");
            }

            context.AddRange(validPersons);

         

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string ImportCompanies(FinanceDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportCompaniesDto[] companyDto = JsonConvert.DeserializeObject<ImportCompaniesDto[]>(jsonString);

            HashSet<Company> validCompanies = new HashSet<Company>();

            foreach (var company in companyDto)
            {


                if (!IsValid(company))
                {
                    sb.AppendLine("Invalid data company!");
                    continue;
                }

                Company isPeopleInValid = validCompanies.FirstOrDefault(x => x.IdEik == company.IdEik);

                if (isPeopleInValid != null)
                {
                    sb.AppendLine("This Person already exist with the same EGN");
                    continue;
                }


                Company currentCompany = new Company()
                {
                    IdEik = company.IdEik,
                    CompanyName = company.CompanyName,
                    AddressCompany = company.AddressCompany,
                    AddressActivity = company.AddressActivity,
                    KidNumber = company.KidNumber,
                    Representing = company.Representing,
                    TypeRepresenting = company.TypeRepresenting,
                    TypeCompany = company.TypeCompany,
                 
                    PhoneNumber = company.PhoneNumber.ToString(),
                    Email = company.Email,
                    Status = company.Status
              

                };


                validCompanies.Add(currentCompany);



                sb.AppendLine($"Successfully imported  {currentCompany.CompanyName} with EIK {currentCompany.IdEik}");
            }

            context.AddRange(validCompanies);



            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string ImportManagers(FinanceDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportMapingManagersDto[] mapingManagersDto = JsonConvert.DeserializeObject<ImportMapingManagersDto[]>(jsonString);

            HashSet<MapingManager> validMapingManagers = new HashSet<MapingManager>();

            foreach (var mapingManager in mapingManagersDto)
            {


                if (!IsValid(mapingManager))
                {
                    sb.AppendLine("Invalid manager!");
                    continue;
                }

                MapingManager ismanagernValid = validMapingManagers.FirstOrDefault(x => x.IdEik == mapingManager.IdEik && x.IdEgn == mapingManager.IdEgn);

                if (ismanagernValid != null)
                {
                    sb.AppendLine("This Manager already exist with the same EGN");
                    continue;
                }


                MapingManager currentMapingManager = new MapingManager()
                {
                    IdEik = mapingManager.IdEik,
                    IdEgn = mapingManager.IdEgn,

                };

             

                validMapingManagers.Add(currentMapingManager);

                sb.AppendLine($"Successfully imported  Manager Map!");

                Console.WriteLine($"{currentMapingManager.IdEik} --{currentMapingManager.IdEgn}");
                context.Add(currentMapingManager);


                context.SaveChanges();


            }



            return sb.ToString().TrimEnd();
        }

        public static string ImportOwnerPerson(FinanceDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportMapingOwnersPersons[] mapingOwnerDto = JsonConvert.DeserializeObject<ImportMapingOwnersPersons[]>(jsonString);

            HashSet<MapingOwnerPerson> validOwner = new HashSet<MapingOwnerPerson>();

            foreach (var owner in mapingOwnerDto)
            {


                if (!IsValid(owner))
                {
                    sb.AppendLine("Invalid owner person!");
                    continue;
                }

                MapingOwnerPerson isOwnerValid = validOwner.FirstOrDefault(x => x.IdEik == owner.IdEik && x.IdEgn == owner.IdEgn);

                if (isOwnerValid != null)
                {
                    sb.AppendLine("This Owner already exist with the same EGN");
                    continue;
                }


                MapingOwnerPerson currentOwnerManager = new MapingOwnerPerson()
                {
                    IdEik = owner.IdEik,
                    IdEgn = owner.IdEgn,
                    Persent = owner.Persent

                };

              

                validOwner.Add(currentOwnerManager);

                sb.AppendLine($"Successfully imported  Owner Map!");

                Console.WriteLine($"{currentOwnerManager.IdEik} --{currentOwnerManager.IdEgn}");
                context.Add(currentOwnerManager);


                context.SaveChanges();


            }



            return sb.ToString().TrimEnd();
        }

        public static string ImportOwnerCompany(FinanceDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportMapingOwnersCompany[] mapingOwnerDto = JsonConvert.DeserializeObject<ImportMapingOwnersCompany[]>(jsonString);

            HashSet<MapingOwnerCompany> validOwner = new HashSet<MapingOwnerCompany>();

            foreach (var owner in mapingOwnerDto)
            {


                if (!IsValid(owner))
                {
                    sb.AppendLine("Invalid owner company!");
                    continue;
                }

                MapingOwnerCompany isOwnerValid = validOwner.FirstOrDefault(x => x.IdEik == owner.IdEik && x.IdEikOwner == owner.IdEikOwner);

                if (isOwnerValid != null)
                {
                    sb.AppendLine("This Owner already exist with the same EIK");
                    continue;
                }


                MapingOwnerCompany currentOwnerManager = new MapingOwnerCompany()
                {
                    IdEik = owner.IdEik,
                    IdEikOwner = owner.IdEikOwner,
                    Persent = owner.Persent

                };


                validOwner.Add(currentOwnerManager);

                sb.AppendLine($"Successfully imported  Owner Map!");

                Console.WriteLine($"{currentOwnerManager.IdEik} --{currentOwnerManager.IdEikOwner}");
                context.Add(currentOwnerManager);


                context.SaveChanges();


            }



            return sb.ToString().TrimEnd();
        }



        public static string ImportReports(FinanceDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportReportDto[] reportDto = JsonConvert.DeserializeObject<ImportReportDto[]>(jsonString);

            HashSet<ReportData> validReports = new HashSet<ReportData>();

            foreach (var report in reportDto)
            {


                if (!IsValid(report))
                {
                    sb.AppendLine("Invalid data company!");
                    continue;
                }

                //ReportData isReportInValid = validReports.FirstOrDefault(x => x.ReportId == report.ReportId);

                //if (isReportInValid != null)
                //{
                //    sb.AppendLine("This Report already exist with the same ReportId");
                //    continue;
                //}


                ReportData currentReport = new ReportData()
                {


                    IdEik = report.IdEik,
                    YearReport=2019,
                   Assets=report.Assets2019,
                   AnnualTurnover=report.AnnualTurnover2019,
                   CountOfEmployees=report.NumberEmployees2019

                };


                validReports.Add(currentReport);



                sb.AppendLine($"Successfully imported  {report.IdEik} for year {report.YearReport}");
            }

            context.AddRange(validReports);



            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string ImportReportsMaping(FinanceDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportMapingReports[] mapingReportDto = JsonConvert.DeserializeObject<ImportMapingReports[]>(jsonString);

            HashSet<MapingCompanyReport> validReports = new HashSet<MapingCompanyReport>();

            foreach (var report in mapingReportDto)
            {


                if (!IsValid(report))
                {
                    sb.AppendLine("Invalid report!");
                    continue;
                }

                MapingCompanyReport isReportValid = validReports.FirstOrDefault(x => x.IdEik == report.IdEik && x.ReportId == report.ReportId);

                if (isReportValid != null)
                {
                    sb.AppendLine("This Report Already exist");
                    continue;
                }


                MapingCompanyReport currentReportMaping = new MapingCompanyReport()
                {
                    IdEik = report.IdEik,
                     ReportId=report.ReportId

                };


                validReports.Add(currentReportMaping);

                sb.AppendLine($"Successfully imported  Owner Map!");

                Console.WriteLine($"{currentReportMaping.IdEik} --{currentReportMaping.ReportId}");
                context.Add(currentReportMaping);


                context.SaveChanges();


            }



            return sb.ToString().TrimEnd();
        }


        public static string ImportOpr(FinanceDbContext context, long idEik, string Companyname, int Year, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPnlDto[] reportDto = JsonConvert.DeserializeObject<ImportPnlDto[]>(jsonString);
         
            int currentYear=0;

            foreach (var report in reportDto)
            {

                Year = Year - currentYear;


                if (!IsValid(report))
                {
                    sb.AppendLine("Invalid data report!");
                    continue;
                }

                PNL currentPnl = new PNL()
                {

                    idEikYear = long.Parse(idEik.ToString()+Year.ToString()),
                    Eik=idEik,
                    CompanyName=Companyname,
                    Year=Year,

                    N10100 = report.N10100,
                    N10200 = report.N10200,
                    N10210 = report.N10210,
                    N10220 = report.N10220,
                    N10300 = report.N10300,
                    N10310 = report.N10310,
                    N10311 = report.N10311,
                    N10320 = report.N10320,
                    N10321 = report.N10321,
                    N10400 = report.N10400,
                    N10410 = report.N10410,
                    N10411 = report.N10411,
                    N10413 = report.N10413,
                    N10412 = report.N10412,
                    N10420 = report.N10420,
                    N10500 = report.N10500,
                    N10510 = report.N10510,
                    N10520 = report.N10520,
                    N10000 = report.N10000,
                    N11100 = report.N11100,
                    N11110 = report.N11110,
                    N11200 = report.N11200,
                    N11210 = report.N11210,
                    N11220 = report.N11220,
                    N11201 = report.N11201,
                    N11000 = report.N11000,
                    N14000 = report.N14000,
                    N13000 = report.N13000,
                    N14100 = report.N14100,
                    N14200 = report.N14200,
                    N14300 = report.N14300,
                    N14400 = report.N14400,
                    N14500 = report.N14500,
                    N15100 = report.N15100,
                    N15110 = report.N15110,
                    N15120 = report.N15120,
                    N15130 = report.N15130,
                    N15131 = report.N15131,
                    N15132 = report.N15132,
                    N15133 = report.N15133,
                    N15200 = report.N15200,
                    N15300 = report.N15300,
                    N15310 = report.N15310,
                    N15400 = report.N15400,
                    N15410 = report.N15410,
                    N15411 = report.N15411,
                    N15420 = report.N15420,
                    N15430 = report.N15430,
                    N15000 = report.N15000,
                    N16100 = report.N16100,
                    N16110 = report.N16110,
                    N16200 = report.N16200,
                    N16210 = report.N16210,
                    N16300 = report.N16300,
                    N16310 = report.N16310,
                    N16320 = report.N16320,
                    N16330 = report.N16330,
                    N16000 = report.N16000,
                    N19000 = report.N19000,
                    N18000 = report.N18000,
                    N19100 = report.N19100,
                    N19200 = report.N19200,
                    N19500 = report.N19500,


                };

                var exist = context.PNLs.FirstOrDefault(x => x.idEikYear == currentPnl.idEikYear);

                if (exist==null)
                {
                    context.PNLs.AddAsync(currentPnl);

                    sb.AppendLine($"Successfully imported  {currentPnl.idEikYear} for year {currentPnl.Year}");

                    context.SaveChanges();
                }

              

                currentYear = 1;
            }




            return sb.ToString().TrimEnd();


        }

        



        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
