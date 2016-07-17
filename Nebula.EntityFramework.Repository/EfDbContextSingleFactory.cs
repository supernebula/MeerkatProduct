using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebula.EntityFramework.Repository
{
    public interface IEfDbContextLazySingleFactory
    {
        TDbContext Current<TDbContext>() where TDbContext : DbContext, new();

        Lazy<DbContext> CurrentLazy();
    }


    public class EfDbContextLazySingleFactory : IEfDbContextLazySingleFactory
    {

        private Dictionary<Type, DbContext> _dbContexts;

        public EfDbContextLazySingleFactory()
        {
            _dbContexts = new Dictionary<Type, DbContext>();
        }

        public Lazy<DbContext> CurrentLazy()
        {
            throw new NotImplementedException();
        }

        public TDbContext Current<TDbContext>() where TDbContext : DbContext, new()
        {
            DbContext item = null;
            if (_dbContexts.ContainsKey(typeof(TDbContext)))
                _dbContexts.TryGetValue(typeof(TDbContext), out item);
            if (item != null)
                return (TDbContext) item;
            _dbContexts.Remove(typeof(TDbContext));

            item = new TDbContext();
            _dbContexts.Add(item.GetType(), item);
            OnDbContextReturning(item);
            return (TDbContext)item;
        }

        public void OnDbContextReturning(DbContext dbContext)
        {
            throw new NotImplementedException();
        }
    }

    public static class LazyExtension
    {
        public static void LazyDo(this Lazy<DbContext> lazy, Action<DbContext> action)
        {
            action.Invoke(lazy.Value);
        }

    }
}
