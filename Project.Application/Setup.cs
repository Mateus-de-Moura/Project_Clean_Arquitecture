using Microsoft.Extensions.DependencyInjection;
using Project.Application.Interfaces;
using Project.Application.Mappers;
using Project.Application.Services;
using Project.Core.Iterfaces;

namespace Project.Application
{
    public static class Setup
    {
        public static IServiceCollection AddModuleCore(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(DtoToDomain));
            services.AddAutoMapper(typeof(DomainToDto));
            return services;

        }
    }
}