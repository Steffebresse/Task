using System.Threading.Tasks;

namespace Domain
{
    public class TaskManager
    {
        public List<Task> Tasks { get; set; } = new List<Task>();

        public void AddTask(string description)
        {
            var task = new Task(description);

            

            if (!string.IsNullOrWhiteSpace(description))
            { Tasks.Add(task); }
            else
            { 
                throw new ArgumentNullException("description is shit");
            }
        }

        public void MarkComplete(int id)
        {
            if (Tasks.FirstOrDefault(task => task.Id == id) != null)
            {
                Tasks.FirstOrDefault(task => task.Id == id).IsCompleted = true;
            }
            

        }
        
        public void ShowTasks()
        {
            foreach (var task in Tasks)
            {
                Console.WriteLine($"Desc: {task.Description} Id: {task.Id} Completet: {task.IsCompleted}");
            }
        }

        public (List<Task> completeTasks, List<Task> incompleteTasks) ListTasks()
        {
            List<Task> completeTasks = new List<Task>();
            List<Task> incompleteTasks = new List<Task>();

            foreach (var task in Tasks)
            {
                if (task.IsCompleted)
                {
                    completeTasks.Add(task);
                }
                else
                {
                    incompleteTasks.Add(task);
                }
            }

            return (completeTasks, incompleteTasks);
        }
    }
}
