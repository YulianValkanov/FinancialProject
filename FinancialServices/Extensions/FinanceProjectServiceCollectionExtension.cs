using FinancialServices.Areas.Administration.Services;
using FinancialServices.Contracts;
using FinancialServices.Data.Common;
using FinancialServices.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FinanceProjectServiceCollectionExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IOwnerPersonService, OwnerPersonService>();
            services.AddScoped<IOwnerCompanyService, OwnerCompanyService>();
            services.AddScoped<IFormulasService, FormulasService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<ICreditService, CreditService>();
         


            return services;

        }



    }
}
