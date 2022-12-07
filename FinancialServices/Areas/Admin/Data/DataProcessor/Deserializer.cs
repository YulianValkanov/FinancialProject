namespace FinancialServices.Areas.Administration.Data.DataProcessor
{
    using FinancialServices.Areas.Administration.Data.DataProcessor.ImportDto;
    using FinancialServices.Data;
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



        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
