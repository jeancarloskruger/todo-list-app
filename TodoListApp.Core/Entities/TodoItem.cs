using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListApp.Core.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public Guid TodoId { get; set; }
    }
}
