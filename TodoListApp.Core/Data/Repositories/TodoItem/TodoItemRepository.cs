using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TodoListApp.Core.Entities;

namespace TodoListApp.Core.Data.Repositories.TodoItem
{
    public class TodoItemRepository : ITodoItemRepository
    {
        public readonly TodoListContext context;
        public TodoItemRepository(TodoListContext context)
        {
            this.context = context;
        }
        public virtual IQueryable<Entities.TodoItem> Set() =>
            context.Set<Entities.TodoItem>();
        public Entities.TodoItem Add(Entities.TodoItem entity)
        {
            context.Set<Entities.TodoItem>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public bool Any(Expression<Func<Entities.TodoItem, bool>> predicate) =>
            Set().Any(predicate);

        public void Delete(Entities.TodoItem entity)
        {
            context.Set<Entities.TodoItem>().Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<Entities.TodoItem> Get(Expression<Func<Entities.TodoItem, bool>> predicate) =>
              Set()
                .AsNoTracking()
                .Where(predicate);

        public void Update(Entities.TodoItem entity)
        {
            if (context.Entry(entity).State != EntityState.Modified)
                context.Entry(entity).State = EntityState.Modified;
            context.Set<Entities.TodoItem>().Update(entity);
            context.SaveChanges();
        }
    }
}
