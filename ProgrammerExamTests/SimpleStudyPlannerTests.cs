namespace ProgrammerExamTests
{
    [TestClass]
    public class SimpleStudyPlannerTests
    {
        [TestMethod]
        public void Test_1_TwoPossibleCombinations()
        {
            var items = new Topic[] { 
                new Topic { Time = 1, QCount = 1 }, 
                new Topic { Time = 2, QCount = 2 }, 
                new Topic { Time = 3, QCount = 3 } };
            
            var solution = StudyPlanner.Solve(items, 3);
            Assert.AreEqual(3, solution.TotalTime);
        }
        
        [TestMethod]
        public void Test_2_OnlyLongestTopic()
        {
            var items = new Topic[] { 
                new Topic { Time = 1, QCount = 1 }, 
                new Topic { Time = 2, QCount = 2 }, 
                new Topic { Time = 3, QCount = 4 } };
            
            var solution = StudyPlanner.Solve(items, 3);
            Assert.AreEqual(4, solution.TotalTime);
        }

        [TestMethod]
        public void Test_3_CombinationOfLongestAndShortest()
        {
            var items = new Topic[] {
                new Topic { Time = 1, QCount = 1 },
                new Topic { Time = 2, QCount = 2 },
                new Topic { Time = 3, QCount = 3 } };

            var solution = StudyPlanner.Solve(items, 4);
            Assert.AreEqual(4, solution.TotalTime);
        }

        [TestMethod]
        public void Test_4_DescendingOrder()
        {
            var items = new Topic[10];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Topic { Time = i + 1, QCount = items.Length - i };
            }
            var solution = StudyPlanner.Solve(items, 10);
            Assert.AreEqual(34, solution.TotalTime);
        }

        [TestMethod]
        public void Test_5_Randomized()
        {
            var items = new Topic[10];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Topic { Time = i + 1, QCount = items.Length - i };
            }
            //randomize items order
            var random = new Random();
            for (int i = 0; i < items.Length; i++)
            {
                var j = random.Next(items.Length);
                var temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
            var solution = StudyPlanner.Solve(items, 10);
            Assert.AreEqual(34, solution.TotalTime);
        }
    }
}