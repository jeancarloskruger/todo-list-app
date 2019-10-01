using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoListApp.Core.Data.Repositories.Todo;
using TodoListApp.Core.Dtos;
using TodoListApp.Core.Entities;
using TodoListApp.Core.Interfaces;

namespace TodoListApp.Core.Services
{
    public class TodoService : ITodoService
    {
        private readonly IMapper mapper;
        private readonly ITodoRepository repository;
        private readonly IHttpContextAccessor httpContextAccessor;
        public TodoService(ITodoRepository repository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        public TodoDto Create(TodoDto todo)
        {
            var aaa = repository.Add(mapper.Map<Todo>(todo));
            return mapper.Map<TodoDto>(aaa);
        }

        public void Delete(string id)
        {
            var todoIdGuid = Guid.Parse(id);
            var todo = repository.Get(a => a.Id == todoIdGuid).FirstOrDefault();
            if (todo != null)
            {
                repository.Delete(todo);
            }
        }

        public TodoDto GetById(string guid)
        {
            return mapper.Map<TodoDto>(repository.Get(a => a.Id.ToString() == guid).FirstOrDefault());
        }

        public List<TodoDto> GetByUsername(string username)
        {
            if (username != null)
            {
                username = username.ToLower();
                return mapper.Map<List<TodoDto>>(repository.Get(a => a.UserName.ToLower().Contains(username)).ToList());
            }
            else
            {
                return new List<TodoDto>();
            }
        }

        public void Share(string username, string email, string todoId)
        {
            var url = httpContextAccessor.HttpContext.Request.Scheme+"://" + httpContextAccessor.HttpContext.Request.Host.Value + "/todo/?guid=" + todoId;
            var subject = $"{username} has shared a list with you";
            var body = $"<html><body> <p><strong>{username}</strong> has shared a list with you</p>" +
                        "<p>Click a link below</p>" +
                        "<p><a href='" + url + "'>Open List</a></p></body></html>";

            EmailService.SendEmail(email, subject, body);
        }
    }
}
