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
        public IActionResult Create(int todoListId)
        {
            var todo = new ToDoItem();
            todo.ToDoListId = todoListId;
            todo.CreationDate = DateTime.Today;
            todo.DueDate = DateTime.Today.AddHours(23).AddMinutes(59);
            return View(todo);
        }

        [HttpPost]
        public IActionResult Create(ToDoItem item)
        {
            toDoService.AddToDo(item);
            return RedirectToAction("ViewToDos", new { id = item.ToDoListId });
        }

        public IActionResult ViewToDos(int id)
        {
            ViewBag.iD = id;
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
