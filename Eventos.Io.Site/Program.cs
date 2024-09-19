using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Eventos.Io.Site.Data;
using Evenos.IO.Infra.CrossCutting.IoC;
using Evenos.IO.Infra.Data.Context;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EventosContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    Console.WriteLine($"ConnectionString: {connectionString}"); // Adicione essa linha para verificar se a string de conexão está sendo lida corretamente
    options.UseSqlServer(connectionString);
});
NativeInjectorBootStrapper.RegisterServices(builder.Services);


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
