using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TodoListApp.Core.Entities;

namespace TodoListApp.Core.Data.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder
                .ToTable("todo");

            builder
                .HasKey(e => e.Id);

        }
    }
}
