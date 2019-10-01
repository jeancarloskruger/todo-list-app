using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoListApp.Core.Dtos;
using TodoListApp.Core.Interfaces;

namespace TodoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService service;
        public TodoController(ITodoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public TodoDto Get(string id)
        {
            return service.GetById(id);
        }

        [HttpPost("create")]
        public TodoDto Create([FromBody] TodoDto todo)
        {
            return service.Create(todo);
        }

        [HttpPut("share/{username}/{mail}/{todoId}")]
        public void Share(string username, string mail, string todoId)
        {
            service.Share(username, mail, todoId);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            service.Delete(id);
        }

        [HttpGet("filter")]
        public List<TodoDto> Filter(string userName)
        {
            return service.GetByUsername(userName);
        }


    }
}
