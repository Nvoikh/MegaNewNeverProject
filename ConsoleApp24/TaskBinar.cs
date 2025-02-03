using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using MessagePack;

namespace ConsoleApp23
{
    // note 1.1: make file class name as a class name
    public class TaskManager
    {
        // note 2: make readonly "private readonly..."
        private List<TaskItem> tasks = new List<TaskItem>();
        private const string FileName = "TaskItem.dat";
        
        // note 3.1: use interface for this (interface only for single method)
        public void LoadTasks()
        {
            if (File.Exists(FileName))
            {
                using var stream = new FileStream(FileName, FileMode.Open);
                if (stream.Length > 0) 
                {
                   tasks.AddRange(MessagePackSerializer.Deserialize<List<TaskItem>>(stream));



                }
            }
        }

        // note 3.2: use interface for this (interface only for single method)
        public void SaveTasks()
        {
            using (var stream = new FileStream(FileName, FileMode.Create))
            {
                MessagePackSerializer.Serialize(stream, tasks);

            }
        }


        // note 3.3: use interface for this (interface only for single method)
        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
        }
            

        // note 3.4: use interface for this (interface only for single method)
        public bool RemoveTask(int taskId)
        {
            var task = tasks.Find(t => t.Id == taskId);
            if (task != null)
            {
                tasks.Remove(task);
                return true;
            }
            return false;
        }

        // note 4: it belongs to the presentation layer, move it to separated class, let's split business logic and presentation
        public void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available...");
                return;
            }

            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }

        // note 3.5: use interface for this (interface only for single method)
        public TaskItem GetTaskById(int id)
        {
            return tasks.Find(t => t.Id == id);
        }
    }
}
