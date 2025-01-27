using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();
        private const string FileName = "tasks.dat";

        
        public void LoadTasks()
        {
            if (File.Exists(FileName))
            {
                using (var stream = new FileStream(FileName, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    
                }
            }
        }

        
        public void SaveTasks()
        {
            using (var stream = new FileStream(FileName, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                
            }
        }

        
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

       
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

        
        public Task GetTaskById(int id)
        {
            return tasks.Find(t => t.Id == id);
        }
    }
}
