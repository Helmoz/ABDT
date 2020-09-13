using System;
using System.Collections.Generic;

namespace StackWithMin
{
    public class StackWithMin<T> : Stack<T> where T: struct, IComparable<T>
    {
        private Stack<T> Minimals { get; } = new Stack<T>();
        
        public T Min => Minimals.Count == 0 
            ? (T)typeof(T).GetField("MaxValue")?.GetValue(null)
            : Minimals.Peek();

        public new void Push(T item)
        {
            if (item.CompareTo(Min) <= 0)
            {
                Minimals.Push(item);
            }
            base.Push(item);
        }

        public new T Pop()
        {
            var item = base.Pop();
            if (item.CompareTo(Min) == 0)
            {
                Minimals.Pop();
            }

            return item;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var a = new StackWithMin<int>();
            a.Push(5);
            a.Push(3);
            Console.WriteLine(a.Min);
            a.Push(2);
            Console.WriteLine(a.Min);
            Console.WriteLine(a.Pop());
            Console.WriteLine(a.Pop());
            Console.WriteLine(a.Min);
        }
    }
}
