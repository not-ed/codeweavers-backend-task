using System.Collections.Generic;

namespace KanbanConsoleApp.Features.Tasks
{
    public class TaskRepository
    {
        private readonly List<Task> _tasks = new List<Task>();

        public void SaveTask(Task task)
        {
            _tasks.Add(task);
        }

        public List<Task> GetTasks()
        {
            var tasksToReturn = new List<Task>();

            foreach (var task in _tasks)
            {
                tasksToReturn.Add(new Task
                {
                    Id = task.Id,
                    Description = task.Description,

                    // CASE 5: The Client Name was never included when reconstructing a List to return, causing it to be null.
                    ClientName = task.ClientName,
                });
            }

            return tasksToReturn;
        }

        // CASE 7: Added Repository functionality to swap Tasks.
        public void SwapTasks(Task left, Task right)
        {
            for (int i = 0; i < _tasks.Count; i++)
            {
                // It is presumed that all IDs given to a task would be unique like in a real-world scenario, and appropriate to use as a comparison point as a result.
                if (_tasks[i].Id == right.Id)
                {
                    _tasks[i] = left;
                }
                else if (_tasks[i].Id == left.Id) 
                {
                    _tasks[i] = right;
                }
            }
        }
    }
}
