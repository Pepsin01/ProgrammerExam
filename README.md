# ProgrammerExam
This repository is public since 27.3.2023 - 23:59
## The problem:
A programmer has an upcoming exam and only has N hours left to prepare. The textbook has M topics, each of which requires a certain amount of hours Ti for studying, and has a certain number of questions Ki that could potentially appear on the exam. Unfortunately, N hours is not enough time to completely study all the topics, but the exam task will have L questions, chosen randomly from all the questions in the textbook with an equal probability. What is the best way to use limited time to maximize the chances of getting the best possible grade?

## The solution:
We have to maximize the number of questions that we can answer correctly and that will maximize our chances of getting the best possible grade.
If we think of number of question in the topic as a value of that topic and the time it takes us to study the topic as a weight of that topic then this problem is identical to the *knapsack problem*.
The *knapsack problem* is well known NP-complete problem and maybe the best solution to it is to use dynamic programming.
The solution is to create a table of size (NumberOfTopics + 1) x (TimeWeHave + 1).
The table will contain the maximum number of questions we can answer correctly if we have j hours left and we have studied i topics.
Total number of learned question will be equal to the value in the bottom right corner of the table.

## Implementation:
This problem is solved by static method `Solve` in static class `StudyPlanner` in file [StudyPlanner.cs](ProgrammerExam/StudyPlanner.cs).
Method takes two arguments, an array of Topic structs and positive integer that stands for the time we have to study until the exam, and
returns StudyPlan struct with optimal plan for the study session that maximizes number of learned questions.
