using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace ConsoleApp23
{
    // note 1.2: make file class name as a class name
    // note 6: no need to use partial class here
    [MessagePackObject]
    public partial class TaskItem
    {
        // note 5.1: Id should be readonly (at least try to make private set or init instead of set)
        [Key(0)]
        public int Id { get; set; }

        [Key(1)]
        public string Title { get; set; }

        [Key(2)]
        public string Description { get; set; }

        [Key(3)]
        public bool IsCompleted { get; set; }

        // note 5.2: try to avoid unused properties
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