using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace SimpleTasksManager
{
    internal class TaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; } = null!;
        public TaskDbContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["TasksDB"].ConnectionString);

        public void CreateTask(string newTitle, string newDescription, DateTime newDueDate)
        {
            var task = new Task
            {
                Title = newTitle,
                Description = newDescription,
                Date = newDueDate
            };
            Tasks.Add(task);
            SaveChanges();
        }
        public void DeleteTask(int id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                Tasks.Remove(task);
                SaveChanges();
            }
            else Console.WriteLine("Task not found");
        }
        public void Update(int taskId, string newTitle, string newDescription, DateTime newDueDate)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.Title = newTitle;
                task.Description = newDescription;
                task.Date = newDueDate;

                SaveChanges();
            }
            else Console.WriteLine("Task not found");

        }
        public Task GetTask(int id)
        {
            return Tasks.FirstOrDefault(t => t.Id == id);
        }
        public List<Task> GetAllTask()
        {
            return Tasks.ToList();
        }
    }
}
