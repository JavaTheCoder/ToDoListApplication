namespace ToDoItemTests
{
    [TestFixture]
    public class Tests
    {
        // Arrange
        private ToDoItem item = new ToDoItem
        {
            Title = "Finish this project",
            Description = "finish the whole project and present it",
            CreationDate = DateTime.Now,
            DueDate = DateTime.Parse("11/11/2022 15:40:00 +5:00")
        };

        private ToDoItem itemWithStatus = new ToDoItem
        {
            Title = "Create Unit Tests",
            Description = "create some unit tests",
            CreationDate = DateTime.Now,
            DueDate = DateTime.Parse("11/11/2022 19:40:00 +5:00"),
            Status = "In Progress"
        };

        /// <summary>
        /// Method to check if the default value works for property - "Status", which is "Not Started"
        /// </summary>
        [Test]
        public void CreatingInstanceWithoutStatus()
        {
            // Assert
            Assert.That(item.Status, Is.EqualTo("Not Started"));
        }

        /// <summary>
        /// Method to check if the overriden ToString() method works
        /// </summary>
        [Test]
        public void CheckingPublicMethodsToString()
        {
            // Assert
            Assert.That(item.ToString(), Is.EqualTo($"{item.Id}.{item.Title} - {item.Description}." +
                $" Created on {item.CreationDate}. Due to {item.DueDate}. Status - {item.Status}"));
        }

        /// <summary>
        /// Method to check if Status property of a TodoItem changes
        /// </summary>
        [Test]
        public void ChangingStatusValue()
        {
            itemWithStatus.Status = "Completed";

            // Assert
            Assert.That(itemWithStatus.Status, Is.EqualTo("Completed"));
        }
    }

}