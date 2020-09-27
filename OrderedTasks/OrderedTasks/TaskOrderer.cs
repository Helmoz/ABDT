using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OrderedTasks
{
    public class TaskOrderer : IEnumerable<Task>
    {
        private Dictionary<int, Task> Nodes { get; } = new Dictionary<int, Task>();

        public int TasksCount => Nodes.Count;

        public void Add(int taskNumber, int dependentTaskNumber)
        {
            var taskNode = GetTaskNode(taskNumber);
            
            var dependentTaskNode = GetTaskNode(dependentTaskNumber);

            dependentTaskNode.PreviousTask?.DependentTasks.Remove(dependentTaskNode);
            dependentTaskNode.PreviousTask = taskNode;
            
            taskNode.DependentTasks.Add(dependentTaskNode);
        }

        private Task GetTaskNode(int taskNumber)
        {
            if (!Nodes.ContainsKey(taskNumber))
            {
                Nodes.Add(taskNumber, new Task(taskNumber));
            }

            return Nodes[taskNumber];
        }

        public Result Order()
        {
            var result = this.Count() == TasksCount
                ? string.Join(" -> ", this)
                : null;

            return new Result(result);
        }

        #region Traversal
        public IEnumerator<Task> GetEnumerator()
        {
            var root = Nodes.FirstOrDefault(x => x.Value.PreviousTask == null);
            return Traversal(root.Value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        private static IEnumerator<Task> Traversal(Task root)
        {
            var queue = new Queue<Task>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                yield return current;

                foreach (var dependentTask in current.DependentTasks ?? Enumerable.Empty<Task>())
                {
                    queue.Enqueue(dependentTask);
                }
            }
        }
        #endregion
    }
}