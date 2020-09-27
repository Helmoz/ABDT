using System.Collections.Generic;

namespace OrderedTasks
{
    public class Task
    {
        private int? TaskNumber { get; }

        public List<Task> DependentTasks { get; } = new List<Task>();

        public Task PreviousTask { get; set; }

        public Task(int? taskNumber)
        {
            TaskNumber = taskNumber;
        }

        public override string ToString()
        {
            return TaskNumber.ToString();
        }
    }
}