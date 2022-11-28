using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using ToDoListApplication.Models;
using ToDoListDomainEntities;

namespace ToDoListApplication.Service
{
    public class ToDoService : IToDoService
    {
        private readonly ApplicationDBContext _context;

        public ToDoService(ApplicationDBContext context)
        {
            _context = context;
        }

        public ToDoItem AddToDo(ToDoItem item)
        {
            _context.ToDoItems.Add(item);
            _context.SaveChanges();
            return item;
        }

        public ToDoList AddToDoList(ToDoList list)
        {
            _context.ToDoLists.Add(list);
            _context.SaveChanges();
            return list;
        }

        public void DeleteToDo(int id)
        {
            var item = _context.ToDoItems.ToList().Find(t => t.Id == id);
            _context.Remove(item);
            _context.SaveChanges();
        }

        public void DeleteToDoList(int id)
        {
            var list = _context.ToDoLists.ToList().Find(l => l.Id == id);
            _context.Remove(list);
            _context.SaveChanges();
        }

        public ToDoItem GetToDo(int id)
        {
            return _context.ToDoItems.FirstOrDefault(t => t.Id == id);
        }

        public ToDoList GetToDoList(int id)
        {
            return _context.ToDoLists.FirstOrDefault(l => l.Id == id);
        }

        public void UpdateToDo(int id, ToDoItem item)
        {
            var oldToDo = _context.ToDoItems.ToList().Find(t => t.Id == id);
            oldToDo.Title = item.Title;
            oldToDo.Description = item.Description;
            oldToDo.CreationDate = item.CreationDate;
            oldToDo.DueDate = item.DueDate;
            oldToDo.Status = item.Status;
            _context.SaveChanges();
        }

        public void UpdateToDoList(int id, ToDoList list)
        {
            var oldToDoList = _context.ToDoLists.ToList().Find(l => l.Id == id);
            oldToDoList.Name = list.Name;
            _context.SaveChanges();
        }
    }
}
