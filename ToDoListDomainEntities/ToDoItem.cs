using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ToDoListDomainEntities
{
    /// <summary>
    /// ToDoItem Model Class
    /// </summary>
    public class ToDoItem   
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime DueDate { get; set; }

        // TODO: Make status enum
        public string Status { get; set; } = "Not Started";

        // Navigation Properties
        public int ToDoListId { get; set; }

        public ToDoList ToDoList { get; set; }

        // ToString Method
        public override string ToString()
        {
            return $"{Id}.{Title} - {Description}. Created on {CreationDate}. Due to {DueDate}. Status - {Status}";
        }
    }
}
