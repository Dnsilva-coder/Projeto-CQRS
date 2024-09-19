using Evenos.IO.Infra.Data.Context;
using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Evenos.IO.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected EventosContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(EventosContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();

        }

        public virtual void Adicionar(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
        }

        public virtual void Atualizar(TEntity obj)
        {
            Db.Set<TEntity>().Update(obj);
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Remover(Guid id)
        {
            DbSet.Remove(ObterPorId(id));
            //DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
           return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
