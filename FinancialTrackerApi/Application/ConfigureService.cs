using Application.Category.Queries;
using Application.Dtos;
using Application.Transaction.Queries;
using Domaine.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
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
                cfg.CreateMap<TransactionEntity, TransactionDto>()
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.TransactionTypeId));

                cfg.CreateMap<CategoryEntity, CategoryDto>();
            });

            services.AddTransient<IValidator<GetTransactionsByTypeQuery>, GetTransactionByTypeValidator>();
            services.AddTransient<IValidator<GetTransactionsGroupedByCategoryQuery>, GetTransactionGroupedByCategoryValidator>();


            return services;
        }
    }
}
