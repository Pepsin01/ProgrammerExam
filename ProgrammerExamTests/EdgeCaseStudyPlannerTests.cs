namespace ProgrammerExamTests
{
    [TestClass]
    public class EdgeCaseStudyPlannerTests
    {
        [TestMethod]
        public void Test_1_LotOfTime()
        {
            var items = new Topic[] {
                new Topic { Time = 1, QCount = 1 },
                new Topic { Time = 2, QCount = 2 },
                new Topic { Time = 3, QCount = 3 }, };

            var solution = StudyPlanner.Solve(items, 10);
            Assert.AreEqual(6, solution.TotalTime);
        }
        
        [TestMethod]
        public void Test_2_SameTopics()
        {
            var items = new Topic[] {
                new Topic { Time = 2, QCount = 2 },
                new Topic { Time = 2, QCount = 2 },
                new Topic { Time = 2, QCount = 2 } };

            var solution = StudyPlanner.Solve(items, 6);
            Assert.AreEqual(6, solution.TotalTime);
        }

        [TestMethod]
        public void Test_3_TooLongTopics()
        {
            var items = new Topic[] {
                new Topic { Time = 2, QCount = 2 },
                new Topic { Time = 3, QCount = 3 },
                new Topic { Time = 4, QCount = 4 }, };

            var solution = StudyPlanner.Solve(items, 1);
            Assert.AreEqual(0, solution.TotalTime);
        }
    }
}
