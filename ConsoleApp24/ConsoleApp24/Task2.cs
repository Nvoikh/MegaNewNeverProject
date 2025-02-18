using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace ConsoleApp23
{
    [MessagePackObject]
    public partial class TaskItem
    {
       
        [Key(0)]
        public int Id { get; set; }

        [Key(1)]
        public string Title { get; set; }

        [Key(2)]
        public string Description { get; set; }

        [Key(3)]
        public bool IsCompleted { get; set; }

        [Key(4)]
        public string? AddTask { get; private set; }

        // All fields or properties that should not be serialized must be annotated with [IgnoreMember].

       
        public TaskItem(int id, string title, string description)
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