using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Nebula.Repository.Model;

namespace Nebula.Repository.Repository
{
    public interface IRepository<T> where T : IPrimaryKey
    {
        void Add(T entity);
        T Find(Guid id);

        T Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> Query();

        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);

        int Update(T entity);

        int Delete(T entity);

        int Delete(Guid id);

        IPaged<T> Paged(int index, int size);

        IPaged<T> Paged(Expression<Func<T, bool>> predicate, int index, int size);

    }
}
