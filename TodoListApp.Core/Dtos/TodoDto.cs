using System;
using System.Collections.Generic;

namespace TodoListApp.Core.Dtos
{
    public class TodoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public ICollection<TodoItemDto> Items { get; set; }   
    }
}
