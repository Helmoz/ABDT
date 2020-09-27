using NUnit.Framework;
using OrderedTasks;

namespace OrderedTasksTest
{
    public class Tests
    {
        [Test]
        public void RegularOrderingTest()
        {
            var taskOrderer = new TaskOrderer
            {
                {1, 2},
                {2, 5},
                {2, 4},
                {3, 1},
                {5, 6}
            };

            const string expectedResult = "3 -> 1 -> 2 -> 5 -> 4 -> 6";
            
            Assert.AreEqual(taskOrderer.Order().Value, expectedResult);
        }
        
        [Test]
        public void CollisionTest()
        {
            var taskOrderer = new TaskOrderer
            {
                {1, 2},
                {1, 3},
                {2, 3},
            };

            const string expectedResult = "1 -> 2 -> 3";
            
            Assert.AreEqual(taskOrderer.Order().Value, expectedResult);
        }
        
        [Test]
        public void DoesntExistOrderTest()
        {
            var taskOrderer = new TaskOrderer
            {
                {1, 2},
                {2, 5},
                {2, 4},
                {3, 1},
                {5, 6},
                {10, 11}
            };

            const bool expectedResult = false;
            
            Assert.AreEqual(taskOrderer.Order().HasValue, expectedResult);
        }
    }
}