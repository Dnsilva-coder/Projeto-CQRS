using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Evenos.IO.Infra.CrossCutting.IoC.StartuoExtensions
{
    public static class ApplicationExtensions
    {

        public static IServiceCollection AddCustomizedApp(this IServiceCollection services)
        {
            services.AddScoped<IEventoAppService, EventoAppService>();
            return services;
        }
    }
}
