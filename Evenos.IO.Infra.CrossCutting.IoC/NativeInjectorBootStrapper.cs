using Evenos.IO.Infra.CrossCutting.Bus;
using Evenos.IO.Infra.CrossCutting.IoC.StartuoExtensions;
using Evenos.IO.Infra.Data.Context;
using Evenos.IO.Infra.Data.Repository;
using Evenos.IO.Infra.Data.UoW;
using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.Services;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Eventos.Commands;
using Eventos.IO.Domain.Eventos.Events;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace Evenos.IO.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {

        public static void RegisterServices(IServiceCollection services) {

            services.AddAutoMapperSetup();
            // Application
            services.AddScoped<IEventoAppService, EventoAppService>();

            //Domain Eventos
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<EventoRegistradoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoAtualizadoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoExcluidoEvent>, EventoEventHandler>();

            // Domain - Commands
            services.AddScoped<IHandler<RegistrarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<AtualizarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<ExcluirEventoCommand>, EventoCommandHandler>();

            //infra - Data
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EventosContext>();

            //infra - Bus
            services.AddScoped<IBus,InMemoryBus>();
        }
    }
}
