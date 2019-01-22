using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        public ActionResult Index()
        {
            return View(Repository.list);
        }

        // GET: ToDo/Details/5
        public ActionResult Details(int id)
        {
            var todo = Repository.GetToDoById(id);
            return View(todo);
        }

        // GET: ToDo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDo toDo)
        {
            try
            {
                // Call the Repository with new method we will create
                //Repository.CreateTodo() --missing something
                Repository.CreateToDo(toDo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDo/Edit/5
        public ActionResult Edit(int id)
        {
            var todo = Repository.GetToDoById(id);
            return View(todo);
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToDo toDo)
        {
            try
            {
                Repository.SaveToDo(id, toDo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDo/Delete/5
        public ActionResult Delete(int id)
        {
            var todo = Repository.GetToDoById(id);
            return View(todo);
        }

        // POST: ToDo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ToDo toDo)
        {
            try
            {
                // Repository.DeleteTodo() -- missing something
                Repository.DeleteToDo(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}