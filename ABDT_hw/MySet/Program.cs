using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MySet
{
    public static class MySetExtensions
    {
        public static MySet<T> Union<T>(this MySet<T> firstMySet, MySet<T> secondMySet)
        {
            return MySet<T>.Union(firstMySet, secondMySet);
        }
        
        public static MySet<T> Intersection<T>(this MySet<T> firstMySet, MySet<T> secondMySet)
        {
            return MySet<T>.Intersection(firstMySet, secondMySet);
        }
        
        public static MySet<T> Difference<T>(this MySet<T> firstMySet, MySet<T> secondMySet)
        {
            return MySet<T>.Difference(firstMySet, secondMySet);
        }
        
        public static MySet<T> SymmetricDifference<T>(this MySet<T> firstMySet, MySet<T> secondMySet)
        {
            return MySet<T>.SymmetricDifference(firstMySet, secondMySet);
        }
    }
    public class MySet<T> : IEnumerable<T>
    {
        private List<T> Items { get; set; } = new List<T>();

        public int Count => Items.Count;

        public void Add(T item)
        {
            if (!Items.Contains(item ?? throw new ArgumentNullException(nameof(item))))
            {
                Items.Add(item);
            }
        }

        public void Remove(T item)
        {
            if (!Items.Contains(item ?? throw new ArgumentNullException(nameof(item))))
            {
                throw new KeyNotFoundException($"Элемент {item} не найден в множестве.");
            }

            Items.Remove(item);
        }

        public static MySet<T> Union(MySet<T> firstMySet, MySet<T> secondMySet)
        {
            var resultSet = new MySet<T>();

            var items = new List<T>();

            if (firstMySet.Items.Count > 0)
            {
                items.AddRange(new List<T>(firstMySet.Items));
            }

            if (secondMySet.Items.Count > 0)
            {
                items.AddRange(new List<T>(secondMySet.Items));
            }

            resultSet.Items = items.Distinct().ToList();

            return resultSet;
        }

        public static MySet<T> Intersection(MySet<T> firstMySet, MySet<T> secondMySet)
        {
            var resultSet = new MySet<T>();

            var smallerSet = firstMySet.Count < secondMySet.Count ? firstMySet : secondMySet;
            var biggerSet = firstMySet.Count < secondMySet.Count ? secondMySet : firstMySet;

            resultSet.Items.AddRange( smallerSet.Items
                .Where(item => biggerSet.Items.Contains(item))
                .Distinct());

            return resultSet;
        }

        public static MySet<T> Difference(MySet<T> firstSet, MySet<T> secondSet)
        {
            var resultSet = new MySet<T>();
            
            resultSet.Items.AddRange(firstSet.Items.Where(item => !secondSet.Items.Contains(item)));

            resultSet.Items = resultSet.Items.Distinct().ToList();

            return resultSet;
        }
        
        public static MySet<T> SymmetricDifference(MySet<T> firstSet, MySet<T> secondSet)
        {
            var resultSet = new MySet<T>();
            
            resultSet.Items.AddRange(firstSet.Items.Where(item => !secondSet.Items.Contains(item)));
            resultSet.Items.AddRange(secondSet.Items.Where(item => !firstSet.Items.Contains(item)));

            resultSet.Items = resultSet.Items.Distinct().ToList();

            return resultSet;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var firstSet = new MySet<int> {1, 2, 3, 4, 5};
            var secondSet = new MySet<int> {3, 4, 5, 6, 7};
            Console.WriteLine(string.Join(" ",firstSet.Union(secondSet)));
            Console.WriteLine(string.Join(" ",firstSet.Intersection(secondSet)));
            Console.WriteLine(string.Join(" ",secondSet.Difference(firstSet)));
            Console.WriteLine(string.Join(" ",firstSet.SymmetricDifference(secondSet)));
        }
    }
}