using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TodoListApp.Core.Entities;

namespace TodoListApp.Core.Data.Configurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder
                .ToTable("todoitem");

            builder
                .HasKey(e => e.Id);

            builder
             .Property(e => e.Id)
             .ValueGeneratedOnAdd();
        }
    }
}
