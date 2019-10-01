using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListApp.Core.Dtos;
using TodoListApp.Core.Interfaces;

namespace TodoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {

        private readonly ITodoItemService service;
        public TodoItemController(ITodoItemService service)
        {
            this.service = service;
        }

        [HttpGet("filter")]
        public List<TodoItemDto> Filter(string description, string todoId)
        {
            return service.GetByDescription(description, todoId);
        }


        // POST: api/Todo
        [HttpPost]
        public void Post([FromBody] TodoItemDto todo)
        {
            service.Create(todo);
        }

        [HttpPut("{id}")]
        public void MarkAsDone(int id)
        {
            service.MarkAsDone(id);
        }

        [HttpPut("update/{id}/{description}")]
        public void Update(int id, string description)
        {
            service.Update(id, description);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }

    }
}
