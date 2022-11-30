using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoListApplication.Models;
using ToDoListApplication.Service;
using ToDoListDomainEntities;

namespace ToDoListApplication.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IToDoService toDoService;
        private readonly ApplicationDBContext _context;

        public ToDoListController(IToDoService service, ApplicationDBContext context)
        {
            toDoService = service;
            _context = context;
        }

        public IActionResult HomeView()
        {
            var lists = _context.ToDoLists.ToList();
            return View("Views/ToDoList/View.cshtml", lists);
        }

        [HttpPost]
        public IActionResult Create(ToDoList list)
        {
            toDoService.AddToDoList(list);
            return new RedirectResult("~/ToDoList/HomeView");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("ToDoList/Edit/{id}")]
        public IActionResult Update(int id)
        {
            var oldList = toDoService.GetToDoList(id);
            return View(oldList);
        }

        public IActionResult UpdateToDoList(int id, ToDoList list)
        {
            toDoService.UpdateToDoList(id, list);
            return new RedirectResult("~/ToDoList/HomeView");
        }

        public IActionResult Delete(int id)
        {
            toDoService.DeleteToDoList(id);
            return new RedirectResult("~/ToDoList/HomeView");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}