using System;
using System.Collections.Generic;
using System.Text;
using TodoListApp.Core.Dtos;

namespace TodoListApp.Core.Interfaces
{
    public interface ITodoService
    {
        TodoDto GetById(string guid);
        TodoDto Create(TodoDto todo);
        void Share(string username, string email, string guid);
        List<TodoDto> GetByUsername(string username);
        void Delete(string id);
    }
}
