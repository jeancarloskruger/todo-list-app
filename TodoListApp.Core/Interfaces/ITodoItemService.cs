using System;
using System.Collections.Generic;
using System.Text;
using TodoListApp.Core.Dtos;

namespace TodoListApp.Core.Interfaces
{
    public interface ITodoItemService
    {
        List<TodoItemDto> GetByDescription(string description, string todoId);
        TodoItemDto Create(TodoItemDto todo);
        void MarkAsDone(int id);
        void Delete(int id);
        void Update(int id, string description);
    }
}
