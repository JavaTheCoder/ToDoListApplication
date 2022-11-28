using System.ComponentModel.DataAnnotations;
using ToDoListDomainEntities;

namespace ToDoListDomainEntities
{
    /// <summary>
    /// ToDoList Model Class
    /// </summary>
    public class ToDoList
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        // Navigation Property
        public List<ToDoItem> Items { get; set; } = new List<ToDoItem>();
    }
}
