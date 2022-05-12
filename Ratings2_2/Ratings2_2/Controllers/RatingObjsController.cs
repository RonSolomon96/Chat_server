using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ratings2_2.Data;
using Ratings2_2.Models;
using Ratings2_2.Services;

namespace Ratings.Controllers
{
    public class RatingObjsController : Controller
    {
        //serve is service
        private IRatingObjService serve;

        public RatingObjsController()
        {
            serve = new RatingObjService();
        }

        // GET: RatingObjs
        public IActionResult Index()
        {
            return View(serve.GetAll());
        }

        // GET: RatingObjs/Details/5
        public IActionResult Details(int id)
        {
            return View(serve.Get(id));
        }

        // GET: RatingObjs/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Search")]
        public IActionResult Search(string query)
        {
            var q = from obj in serve.GetAll()
                    where obj.Name.Contains(query) || obj.Description.Contains(query)
                    select obj;
            return View(q.ToList());
        }

        // POST: RatingObjs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string Name, int Rate, string Description)
        {
            serve.Create(Name, Rate, Description);
            return RedirectToAction(nameof(Index));
        }

        // GET: RatingObjs/Edit/5
        public IActionResult Edit(int id)
        {

            return View(serve.Get(id));
        }

        // POST: RatingObjs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string Name, int Rate, string Description)
        {
            serve.Edit(id, Name, Rate, Description);

            return RedirectToAction(nameof(Index));


        }

        // GET: RatingObjs/Delete/5
        public IActionResult Delete(int id)
        {

            return View(serve.Get(id));
        }

        // POST: RatingObjs/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            serve.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}