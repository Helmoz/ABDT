#nullable enable
namespace OrderedTasks
{
    public class Result
    {
        public Result(string? value)
        {
            Value = value;
        }

        public bool HasValue => !string.IsNullOrWhiteSpace(Value);

        public string? Value { get; }
    }
}