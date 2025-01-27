using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public Task(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = true; 
        }

        public override string ToString()
        {
            return $"ID: {Id}, Title: {Title}, Description: {Description}, Completed: {IsCompleted}";
        }
    }
}
