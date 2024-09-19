using Eventos.IO.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Evenos.IO.Infra.CrossCutting.IoC.StartuoExtensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services){
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            services.AddAutoMapper(AutoMapperConfiguration.RegisterMapping());
        }
    }
}
