using NBL_USA.Data;
using NBL_USA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBL_USA.WebMVC.Controllers
{
    public class TeamController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Team
        public ActionResult Index()
        {
            var model = new TeamListItem[0];
            return View(_db.Teams.ToList());
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
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                _db.Teams.Add(team);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }
    }
}