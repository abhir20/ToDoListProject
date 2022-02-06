using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using To_doProject.Business;
using To_doProject.Business.Entitites;

namespace To_doProject.Controllers
{
   [Route("api/[controller]/[action]")]
    public class ToDoListController : Controller
    {
        


        // GET: ToDoListController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ToDoList()
        {
            return View();
        }
        // GET: ToDoListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ToDoListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDoListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ToDoListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
