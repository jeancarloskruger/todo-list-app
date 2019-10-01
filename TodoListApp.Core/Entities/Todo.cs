using System;
using System.Collections.Generic;

namespace TodoListApp.Core.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public ICollection<TodoItem> Items { get; set; }
    }
}
