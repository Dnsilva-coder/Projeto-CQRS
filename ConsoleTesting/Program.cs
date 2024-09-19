using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Eventos;
using Eventos.IO.Domain.Eventos.Commands;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Interfaces;
using System;
using System.Linq.Expressions;


class Program
{
    static void Main(string[] args)
    {

        var cmd = new RegistrarEventoCommand("DevX", DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), true, 0, true, "Empresa");

        Console.ReadKey();
    }
}