using Application.Category.Queries;
using Application.Interfaces;
using Domaine.Services;
using infrastructure.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace infrastructure
{
    public static class infrastructureServiceExtensions
    {
        public static IServiceCollection ConfigureService(this IServiceCollection services)
        {
            services.AddTransient<ITransactionServcie, TransactionService>();
            services.AddTransient<ICategoryService, CategoryService>();

            return services;
        }
    }
}
