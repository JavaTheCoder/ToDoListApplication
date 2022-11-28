using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoListDomainEntities;

namespace ToDoListApplication.Service
{
    public interface IToDoService
    {
        // ToDoItem methods
        public ToDoItem AddToDo(ToDoItem item);

        public ToDoItem GetToDo(int id);

        public void UpdateToDo(int id, ToDoItem item);

        public void DeleteToDo(int id);

        // TodoList methods
        public ToDoList AddToDoList(ToDoList list);

        public ToDoList GetToDoList(int id);

        public void UpdateToDoList(int id, ToDoList list);

        public void DeleteToDoList(int id);
    }
}
