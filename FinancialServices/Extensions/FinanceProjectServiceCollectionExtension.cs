﻿using FinancialServices.Areas.Administration.Services;
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

            return services;


        }



    }
}
