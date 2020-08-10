using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio
{
    public abstract class Repositorio<TEntidade> : DbContext, IRepositorio<TEntidade>
        where TEntidade : EntityBase, new()
    {
        protected DbContext _db;
        protected DbSet<TEntidade> _dbSet;

        public Repositorio(DbContext dbContext)
        {
            _db = dbContext;
            _dbSet = _db.Set<TEntidade>();
        }

        public void Create(TEntidade Entity)
        {
            if (Entity.Codigo == 0)
            {
                _dbSet.Add(Entity);
            }
            else
            {
                _db.Entry(Entity).State = EntityState.Modified;
            }

            _db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var ent = new TEntidade { Codigo = id };
            _dbSet.Attach(ent);
            _dbSet.Remove(ent);
            _db.SaveChanges();
        }

        public virtual TEntidade Read(int id)
        {
            return _dbSet.Where(x => x.Codigo == id).FirstOrDefault();
        }

        public virtual IEnumerable<TEntidade> Read()
        {
            return _dbSet.AsNoTracking().ToList();
        }
    }
}
