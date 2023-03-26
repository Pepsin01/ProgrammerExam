namespace ProgrammerExamTests
{
    [TestClass]
    public class PerformanceStudyPlannerTests
    {
        [TestMethod]
        public void Test_1_AscendingOrder()
        {
            var items = new Topic[1000];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Topic { Time = i + 1, QCount = i + 1 };
            }
            var solution = StudyPlanner.Solve(items, 10000);
            Assert.AreEqual(10000, solution.TotalTime);
        }

        [TestMethod]
        public void Test_2_AscendingOrder()
        {
            var items = new Topic[10000];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Topic { Time = i + 1, QCount = i + 1 };
            }
            var solution = StudyPlanner.Solve(items, 10000);
            Assert.AreEqual(10000, solution.TotalTime);
        }

        [TestMethod]
        public void Test_3_DescendingOrder()
        {
            var items = new Topic[10000];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Topic { Time = i + 1, QCount = items.Length - i };
            }
            var solution = StudyPlanner.Solve(items, 10000);
            Assert.AreEqual(1390270, solution.TotalTime);
        }
        
        [TestMethod]
        public void Test_4_Randomized()
        {
            var items = new Topic[10000];
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
            var solution = StudyPlanner.Solve(items, 10000);
            Assert.AreEqual(1390270, solution.TotalTime);
        }
    }
}
