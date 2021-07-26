using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using SoftUni.Models;

namespace SoftUni.Controllers
{
    public class TelevisionController : Controller
    {
        public IActionResult Index()
        {
            var allTVs = TVData.GetAll();
            return View(allTVs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TV tv)
        {
            TVData.Add(tv);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            TV tv = TVData.TVs.Where(x => x.Id == id).SingleOrDefault();
            TVData.Delete(tv);
            return RedirectToAction("Index");
        }
    }
}
