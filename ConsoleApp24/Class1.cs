using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ViewTasks()
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
