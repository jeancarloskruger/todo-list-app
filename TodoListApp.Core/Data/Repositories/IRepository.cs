using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TodoListApp.Core.Data.Repositories
{
    public interface IRepository<TEntidade>
    {
        TEntidade Add(TEntidade entity);
        void Update(TEntidade entity);
        void Delete(TEntidade entity);
        IQueryable<TEntidade> Get(Expression<Func<TEntidade, bool>> predicate);
        bool Any(Expression<Func<TEntidade, bool>> predicado);
    }
}
