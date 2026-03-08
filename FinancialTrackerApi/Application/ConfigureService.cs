using Application.Category.Queries;
using Application.Dtos;
using Domaine.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection ConfigureService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<TransactionEntity, TransactionDto>();
            });

            return services;
        }
    }
}
