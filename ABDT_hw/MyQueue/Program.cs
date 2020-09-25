using System;
using System.Collections.Generic;

namespace MyQueue
{
    public class MyQueue<T>
    {
        private Stack<T> FirstStack { get; } = new Stack<T>();
        private Stack<T> SecondStack { get; }= new Stack<T>();
        
        public void Enqueue(T t)
        {
            FirstStack.Push(t);
        }

        public T Dequeue()
        {
            if (SecondStack.Count != 0)
            {
                return SecondStack.Pop();
            }
            
            while (FirstStack.Count != 0)
            {
                SecondStack.Push(FirstStack.Pop());
            }
            
            return SecondStack.Pop();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            Console.WriteLine(queue.Dequeue());
            queue.Enqueue(3);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }
}