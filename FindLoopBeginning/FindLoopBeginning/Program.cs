using System;
using System.Collections.Generic;

namespace FindLoopBeginning
{
    class Program
    {
        private static LinkedListNode<int> FindBeginning(LinkedListNode<int> head) {
            var slow = head;
            var fast = head;

            // Находим первую точку встречи
            while (fast?.Next != null) {
                slow = slow?.Next;
                fast = fast.Next.Next;
                if (slow == fast) {
                    break;
                }
            }

            //Нет петли
            if (fast?.Next == null) {
                return null;
            }

            slow = head;
            while (slow != fast) {
                slow = slow?.Next;
                fast = fast?.Next;
            }

            return fast;
        }

        
        static void Main(string[] args)
        {
            var list = new LinkedList<int>(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Console.WriteLine(FindBeginning(list.First));
        }
    }
}