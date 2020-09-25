using System;
using System.Collections.Generic;

namespace MyStack
{
    public class MyStack<T> {
        private Queue<T> FirstQueue { get; set; } = new Queue<T>();
        private Queue<T> SecondQueue { get; set; } = new Queue<T>();

        public void Push(T item) {
            FirstQueue.Enqueue(item);
        }

        public T Pop() {
            if (FirstQueue.Count == 0) {
                throw new InvalidOperationException("Stack is empty");
            }

            while(FirstQueue.Count > 1) {
                SecondQueue.Enqueue( FirstQueue.Dequeue() );
            }

            var popped = FirstQueue.Peek();

            var tempQ = FirstQueue;
            FirstQueue = SecondQueue;
            SecondQueue = tempQ;

            return popped;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            stack.Push(4);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }
    }
}