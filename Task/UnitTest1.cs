using Domain;
namespace Task
{
    public class UnitTest1
    {
        [Fact]
        public void Add_Two_Tasks_Expect_Two_Tasks()
        {
            // Do
            var taskmanager = new TaskManager();

            taskmanager.AddTask("WhateverDesc");
            taskmanager.AddTask("Korv");

            Assert.Equal(2,taskmanager.Tasks.Count);

            




        }

        [Fact]
        public void MarkComplete_ExistingTaskId_MarksTaskAsCompleted()
        {
            // Arrange
            var taskManager = new TaskManager();
            taskManager.AddTask("Test Task True");
            taskManager.AddTask("Test Task False");
            var taskId = taskManager.Tasks[0].Id;

            // Act
            taskManager.MarkComplete(taskId);

            // Assert
            Assert.True(taskManager.Tasks[0].IsCompleted);
            Assert.False(taskManager.Tasks[1].IsCompleted);
        }

        [Fact]
        public void Get_List_Of_Returned_Tasks()
        {
            // Arrange
            var taskManager = new TaskManager();
            taskManager.AddTask("Test Task True");
            taskManager.AddTask("Test Task False");
            var taskId = taskManager.Tasks[0].Id;

            // Act
            taskManager.MarkComplete(taskId);

            var (completeTasks, incompleteTasks) = taskManager.ListTasks();

            // Assert
            Assert.Single(completeTasks); // Assert that there is one completed task
            Assert.Single(incompleteTasks); // Assert that there are no incomplete tasks
        }


    }
}