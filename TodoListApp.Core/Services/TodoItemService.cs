using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoListApp.Core.Data.Repositories.TodoItem;
using TodoListApp.Core.Dtos;
using TodoListApp.Core.Entities;
using TodoListApp.Core.Interfaces;

namespace TodoListApp.Core.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly IMapper mapper;
        private readonly ITodoItemRepository repository;
        public TodoItemService(ITodoItemRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public TodoItemDto Create(TodoItemDto todo)
        {
            return mapper.Map<TodoItemDto>(repository.Add(mapper.Map<TodoItem>(todo)));
        }

        public void Delete(int id)
        {
            var todoItem = repository.Get(a => a.Id == id).FirstOrDefault();
            if (todoItem != null)
            {
                repository.Delete(todoItem);
            }

        }

        public List<TodoItemDto> GetByDescription(string description, string todoId)
        {
            var todoIdGuid = Guid.Parse(todoId);
            if (description != null)
            {
                description = description.ToLower();
                return mapper.Map<List<TodoItemDto>>(repository.Get(a => a.Description.ToLower().Contains(description) && a.TodoId.Equals(todoIdGuid)).ToList());
            }
            else
            {
                return mapper.Map<List<TodoItemDto>>(repository.Get(a => a.TodoId.Equals(todoIdGuid)).ToList());
            }

        }

        public void MarkAsDone(int id)
        {
            var todoItem = repository.Get(a => a.Id == id).FirstOrDefault();
            if (todoItem != null)
            {
                todoItem.Done = !todoItem.Done;
                repository.Update(todoItem);
            }

        }

        public void Update(int id, string description)
        {
            var todoItem = repository.Get(a => a.Id == id).FirstOrDefault();
            if (todoItem != null)
            {
                todoItem.Description = description;
                repository.Update(todoItem);
            }
        }
    }
}
