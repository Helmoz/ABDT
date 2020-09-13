using System;
using System.Collections.Generic;

namespace NthToLastElement
{
    internal class Program
    {
        private static LinkedListNode<int> NthToLast(LinkedListNode<int> node, int n) {
            var currentNode = node;
            var follower = node;
        
            for (var i = 0; i < n; i++) {
                if (currentNode == null)
                {
                    return null;
                }
                    
                currentNode = currentNode.Next;
            }
        
            if (currentNode == null) return null;
        
            while (currentNode.Next != null) {
                currentNode = currentNode.Next;
                follower = follower?.Next;
            }
      
            return follower;
        }
        
        static void Main(string[] args)
        {
            var list = new LinkedList<int>(new[] { 1, 2, 3, 4 });
            Console.WriteLine(NthToLast(list.First, 0).Value);
            Console.WriteLine(NthToLast(list.First, 1).Value);
            Console.WriteLine(NthToLast(list.First, 2).Value);
            Console.WriteLine(NthToLast(list.First, 3).Value);
        }
    }
}