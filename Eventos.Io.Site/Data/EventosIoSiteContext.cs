using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Eventos.IO.Application.ViewModels;

namespace Eventos.Io.Site.Data
{
    public class EventosIoSiteContext : DbContext
    {
        public EventosIoSiteContext (DbContextOptions<EventosIoSiteContext> options)
            : base(options)
        {
        }

        public DbSet<Eventos.IO.Application.ViewModels.EventoViewModel> EventoViewModel { get; set; } = default!;
    }
}
