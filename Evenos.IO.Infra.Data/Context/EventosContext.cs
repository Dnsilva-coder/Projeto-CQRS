using Microsoft.EntityFrameworkCore;
using Evenos.IO.Infra.Data.Mappings;
using Eventos.IO.Domain.Eventos;
using Eventos.IO.Domain.Models;
using Microsoft.Extensions.Configuration;
using FluentValidation.Results;

namespace Evenos.IO.Infra.Data.Context
{
    public class EventosContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Organizador> Organizadores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public EventosContext(DbContextOptions<EventosContext> options) : base(options)
        {
            
        }
        public EventosContext()
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventoMapping());
            modelBuilder.ApplyConfiguration(new CategoriaMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new OrganizadorMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            Console.WriteLine($"ConnectionString: {connectionString}"); // Adicione essa linha para verificar se a string de conexão está sendo lida corretamente

            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
