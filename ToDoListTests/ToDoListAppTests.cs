namespace ToDoListTests
{
    [TestFixture]
    public class ToDoListAppTests
    {
        // Arrange
        private ToDoList list = new ToDoList
        {
            Name = "Project"
        };

        private ToDoItem item = new ToDoItem
        {
            Id = 0,
            Title = "Finish this project",
            Description = "finish the whole project and present it",
            CreationDate = DateTime.Now,
            DueDate = DateTime.Parse("11/11/2022 15:40:00 +5:00")
        };

        private ToDoItem itemWithStatus = new ToDoItem
        {
            Id = 1,
            Title = "Create Unit Tests",
            Description = "create some unit tests",
            CreationDate = DateTime.Now,
            DueDate = DateTime.Parse("11/11/2022 19:40:00 +5:00"),
            Status = "In Progress"
        };

        /// <summary>
        /// Method to check if a todoitem adds to a todolist
        /// </summary>
        [Test]
        public void AddingToDoItemsToAToDoList()
        {
            item.ToDoList = list;
            list.Items.Add(item);

            // Assert
            Assert.That(item.ToDoListId, Is.EqualTo(list.Id));
        }

        /// <summary>
        /// Method to check if a todolist can be renamed
        /// </summary>
        [Test]
        public void RenamingAToDoList()
        {
            list.Name = "Capstone Project";

            // Assert
            Assert.That(list.Name, Is.EqualTo("Capstone Project"));
        }

        /// <summary>
        /// Method to check if a todolist has a specific todoitems
        /// </summary>
        [Test]
        public void CheckingIfToDoListHasAnItem()
        {
            itemWithStatus.ToDoList = list;
            list.Items.Add(itemWithStatus);

            // Assert
            Assert.That(list.Items.Find(t => t.Id == itemWithStatus.Id), Is.EqualTo(itemWithStatus));
        }

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