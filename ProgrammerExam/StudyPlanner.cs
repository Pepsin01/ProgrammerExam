using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerExam
{
    public struct Topic
    {
        // Time is the time it takes to study the topic.
        public int Time;
        // QCount is the number of questions in the topic.
        public int QCount;
    }
    public struct StudyPlan
    {
        public Topic[] Topics;
        // TotalTime is the total time it takes to study all the topics in the plan.
        public int TotalTime;
    }
    public static class StudyPlanner
    {
        /// <summary>
        /// Plan a study session for the given topics.
        /// </summary>
        /// <param name="topics">Available topics</param>
        /// <param name="timeAvailable">Time for the study session</param>
        /// <returns>Optimal plan for the study session that maximizes number of learned questions.</returns>
        public static StudyPlan Solve(Topic[] topics, int timeAvailable)
        {
            int[,] table = new int[topics.Length + 1, timeAvailable + 1];
            
            //incrementally fill the table with the optimal solution
            for (int i = 1; i <= topics.Length; i++)
            {
                for (int j = 1; j <= timeAvailable; j++)
                {
                    if (topics[i - 1].Time <= j)
                    {
                        table[i, j] = Math.Max(table[i - 1, j], table[i - 1, j - topics[i - 1].Time] + topics[i - 1].QCount);
                    }
                    else
                    {
                        table[i, j] = table[i - 1, j];
                    }
                }
            }
            
            //pick the items that were included in the optimal solution
            List<Topic> solutionItems = new List<Topic>();
            int remainingCapacity = timeAvailable;
            for (int i = topics.Length; i > 0; i--)
            {
                if (table[i, remainingCapacity] != table[i - 1, remainingCapacity])
                {
                    solutionItems.Add(topics[i - 1]);
                    remainingCapacity -= topics[i - 1].Time;
                }
            }
            
            solutionItems.Reverse();
            return new StudyPlan { Topics = solutionItems.ToArray(), TotalTime = table[topics.Length, timeAvailable] };
        }
    }
}
