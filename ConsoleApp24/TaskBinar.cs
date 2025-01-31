﻿using System;
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
    public class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private const string FileName = "TaskItem.dat";

        
        public void LoadTasks()
        {
            if (File.Exists(FileName))
            {
                using var stream = new FileStream(FileName, FileMode.Open) ;
                if (stream.Length > 0) 

                {
                   tasks.AddRange(MessagePackSerializer.Deserialize<List<TaskItem>>(stream));



                }
            }
        }

        
        public void SaveTasks()
        {
            using (var stream = new FileStream(FileName, FileMode.Create))
            {
                MessagePackSerializer.Serialize(stream, tasks);

            }
        }


        public void AddTask(TaskItem task)
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

        
        public TaskItem GetTaskById(int id)
        {
            return tasks.Find(t => t.Id == id);
        }
    }
}
