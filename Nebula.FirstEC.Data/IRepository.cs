using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Nebula.FirstEC.Compoment;
using Nebula.Utilities;

namespace Nebula.FirstEC.Data
{
    public interface IRepository<T> where T : IPrimaryKey
    {
        void Insert(T entity);
        T Find(Guid id);

        T Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> Query();

        IEnumerable<T> Retrieve(Expression<Func<T, bool>> predicate);

        void Update(T item);

        void Delete(T item);

        void Delete(Guid id);

        IPaged<T> Paged(int index, int size);

        IPaged<T> Paged(Expression<Func<T, bool>> predicate, int index, int size);

    }
}
