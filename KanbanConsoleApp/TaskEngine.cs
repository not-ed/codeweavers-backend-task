using System.Collections.Generic;
using KanbanConsoleApp.Features.Clients;
using KanbanConsoleApp.Features.Tasks;

namespace KanbanConsoleApp
{
    public class TaskEngine
    {
        private readonly TaskRepository _taskRepository = new TaskRepository();

        // CASE 2: No means of storing clients was originally defined in the class.
        private readonly List<Client> _clients = new List<Client>();

        public void SaveTask(Task task)
        {
            // TASK 6: Added a check for the existence of the Task's client (if given) before adding the Task into the Repository.
            if (ClientExists(task.ClientName) || task.ClientName == null)
            {
                _taskRepository.SaveTask(task);

                return;
            }

            throw new System.Exception("The supplied Client could not be found.");
        }

        public Task RetrieveTaskById(string id)
        {
            var allTasks = _taskRepository.GetTasks();
            foreach (var task in allTasks)
            {
                // CASE 1: Method originally returned just the first Task with no checks in place, causing the wrong Task description to be passed into Case 1's assertion.
                if (task.Id == id)
                {
                    return task;
                }
            }

            return null;
        }

        public void SaveClient(Client client)
        {
            // CASE 2: Method as a whole originally had no code in its implementation.
            // CASE 3: It is presumed from the case's context and elements that clients should be sorted as they're saved.
            int index = _clients.Count;

            for (int i = 0; i < _clients.Count; i++)
            {
                if (_clients[i].Name.CompareTo(client.Name) > 0)
                {
                    index = i;
                    break;
                }
            }

            _clients.Insert(index,client);
        }

        public List<Client> GetClients()
        {
            // CASE 2: A entirely new (and in turn, empty) Client list was originally being returned each time the method was called rather than the member list of clients.
            return _clients;
        }

        public void RemoveClientByName(string name)
        {
            // CASE 4: Method originally had no code in its implementation.
            foreach (var client in _clients)
            {
                if (client.Name == name)
                {
                    _clients.Remove(client);
                    break;
                }
            }
        }

        public List<Task> GetTasksForClient(string clientName)
        {
            // CASE 5: Empty task List was originally being returned instead of relevant client tasks.
            List<Task> client_tasks = new List<Task>();

            foreach (var task in _taskRepository.GetTasks())
            { 
                if (task.ClientName == clientName)
                {
                    client_tasks.Add(task);
                }
            }

            return client_tasks;
        }

        // CASE 7: Extended Task Engine to allow re-ordering of tasks by invoking a method within the Task Repository.
        // Because the Task Repository passes its contexts by-value when asked for it, telling it to perform the swap internally would be the most straightforward approach to implement.
        public void SwapTasksById(string left_id, string right_id)
        {
            var left = RetrieveTaskById(left_id);
            var right = RetrieveTaskById(right_id);

            // Verify both Tasks actually exist with the IDs given before attempting to tell the Repository to swap them.
            if (left != null && right != null)
            {
                _taskRepository.SwapTasks(left, right);
            }
        }

        // CASE 6: Added a method for checking for the existance of a previously saved client.
        public bool ClientExists(string name)
        {
            foreach (var client in _clients)
            {
                if (client.Name == name) return true;
            }

            return false;
        }
    }
}