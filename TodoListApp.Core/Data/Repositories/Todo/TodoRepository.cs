using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace TodoListApp.Core.Data.Repositories.Todo
{
    public class TodoRepository : ITodoRepository
    {
        public readonly TodoListContext context;
        public TodoRepository(TodoListContext context)
        {
            this.context = context;
        }
        public virtual IQueryable<Entities.Todo> Set() =>
       context.Set<Entities.Todo>();

        public Entities.Todo Add(Entities.Todo entity)
        {
            entity.Id = Guid.NewGuid();
            context.Set<Entities.Todo>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public bool Any(Expression<Func<Entities.Todo, bool>> predicate) =>
            Set().Any(predicate);

        public void Delete(Entities.Todo entity)
        {
            context.Set<Entities.Todo>().Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<Entities.Todo> Get(Expression<Func<Entities.Todo, bool>> predicate) =>
            Set()
                .AsNoTracking().Include(x => x.Items)
                .Where(predicate);

        public void Update(Entities.Todo entity)
        {
            if (context.Entry(entity).State != EntityState.Modified)
                context.Entry(entity).State = EntityState.Modified;
            context.Set<Entities.Todo>().Update(entity);
            context.SaveChanges();
        }
    }
}
