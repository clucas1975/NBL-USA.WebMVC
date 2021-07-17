using NBL_USA.Data;
using NBL_USA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBL_USA.WebMVC.Controllers
{
    public class RosterController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Roster
        public ActionResult Index()
        {
            var model = new RosterListItem[0];
            return View(_db.Rosters.ToList());
        }

        //Add method here VVVV
        //GET
        public ActionResult Create()
        {
            return View();
        }

        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Roster roster)
        {
            if (ModelState.IsValid)
            {
                _db.Rosters.Add(roster);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roster);
        }
    }
}