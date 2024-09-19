using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Eventos.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evenos.IO.Infra.CrossCutting.IoC.StartuoExtensions
{
    public static class InfraDataExtensions
    {
        public static IServiceCollection AddCustomizedInfraData(this IServiceCollection services)
        {
            services.AddScoped<IHandler<RegistrarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<AtualizarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<ExcluirEventoCommand>, EventoCommandHandler>();


            return services;
        }

    }
}
