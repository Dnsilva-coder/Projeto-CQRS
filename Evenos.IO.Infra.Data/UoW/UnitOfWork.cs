using Evenos.IO.Infra.Data.Context;
using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Interfaces;

namespace Evenos.IO.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventosContext _context;

        public UnitOfWork(EventosContext context)
        {
            _context = context;
        }
        public CommandResponse Commit()
        {
            var rowAffected = _context.SaveChanges();
            return new CommandResponse(rowAffected > 0);
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
