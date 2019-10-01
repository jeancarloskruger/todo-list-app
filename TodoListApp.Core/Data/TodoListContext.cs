using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoListApp.Core.Data.Configurations;

namespace TodoListApp.Core.Data
{
   public class TodoListContext : DbContext
    {
        private readonly string connectionString;
        public TodoListContext(string connectionString)
            : base()
        {
            this.connectionString = connectionString;
        }

        public TodoListContext(DbContextOptions<TodoListContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(connectionString))
                optionsBuilder.UseSqlServer(connectionString);

            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new TodoConfiguration());

            modelBuilder
                .ApplyConfiguration(new TodoItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
