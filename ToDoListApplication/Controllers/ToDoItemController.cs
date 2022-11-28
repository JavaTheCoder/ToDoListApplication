using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using ToDoListApplication.Models;
using ToDoListApplication.Service;
using ToDoListDomainEntities;

namespace ToDoListApplication.Controllers
{
    public class ToDoItemController : Controller
    {
        private readonly IToDoService toDoService;
        private readonly ApplicationDBContext _context;

        public ToDoItemController(IToDoService service, ApplicationDBContext context)
        {
            toDoService = service;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Hide()
        {
            return new RedirectResult("~/ToDoItem/ViewTodos");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDoItem item)
        {
            item.ToDoListId = 2;
            toDoService.AddToDo(item);
            
            return new RedirectResult($"~/ToDoItem/ViewTodos/2");
        }

        public IActionResult ViewToDos(int id)
        {
            //var list = toDoService.GetToDoList(id);
            //return View(list.Items);
            return View(_context.ToDoItems.ToList().Where(i => i.ToDoListId == id));
        }

        public IActionResult Delete(int id)
        {
            int listId = toDoService.GetToDo(id).ToDoListId;
            toDoService.DeleteToDo(id);
            return new RedirectResult($"~/ToDoItem/ViewTodos/{listId}");
        }

        public IActionResult Details(int id)
        {
            var item = _context.ToDoItems.ToList().Find(t => t.Id == id);
            return View(item);
        }

        [HttpGet("ToDoItem/Edit/{id}")]
        public IActionResult Update(int id)
        {
            var oldItem = _context.ToDoItems.ToList().Find(t => t.Id == id);
            return View(oldItem);
        }

        public IActionResult UpdateToDo(int id, ToDoItem item)
        {
            int listId = toDoService.GetToDo(id).ToDoListId;
            toDoService.UpdateToDo(id, item);
            return new RedirectResult($"~/ToDoItem/ViewTodos/{listId}");
        }
    }
}
