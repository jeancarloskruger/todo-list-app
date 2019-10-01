using System;

namespace TodoListApp.Core.Dtos
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public Guid TodoId { get; set; }
    }
}
