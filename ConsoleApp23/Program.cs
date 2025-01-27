using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskManager = new TaskManager();
            taskManager.LoadTasks();  

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("To-Do List Application");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Task by ID");
                Console.WriteLine("4. Exit");
                Console.Write("Choose with number : ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        
                        Console.Write("Enter task title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();

                        int id = taskManager.GetTaskById(taskManager.GetTaskById(0)?.Id + 1 ?? 1)?.Id ?? 1; 
                        var newTask = new Task(id, title, description);
                        taskManager.AddTask(newTask);
                        taskManager.SaveTasks(); 
                        Console.WriteLine("Task added!");
                        break;

                    case "2":
                        
                        taskManager.ViewTasks();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "3":
                       
                        Console.Write("Enter task ID to remove: ");
                        int taskIdToRemove = int.Parse(Console.ReadLine());
                        bool removed = taskManager.RemoveTask(taskIdToRemove);
                        if (removed)
                        {
                            taskManager.SaveTasks();
                            Console.WriteLine("Task removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No task found with that ID.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "4":
                        
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}
