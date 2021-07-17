using NBL_USA.Data;
using NBL_USA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBL_USA.WebMVC.Controllers
{
    [Authorize]
    public class LeagueStaffController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: LeagueStaff
        public ActionResult Index()
        {
            var model = new LeagueStaffListItem[0];
            return View(model);
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
        public ActionResult Create(LeagueStaff leagueStaff)
        {
            if (ModelState.IsValid)
            {
                _db.LeagueStaffs.Add(leagueStaff);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leagueStaff);
        }
    }
}