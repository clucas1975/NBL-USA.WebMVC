using Microsoft.AspNet.Identity;
using NBL_USA.Data;
using NBL_USA.Models;
using NBL_USA.Services;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeagueStaffService(userId);
            var model = service.GetLeagueStaffs();

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
        public ActionResult Create(LeagueStaff model)
        {
            if (ModelState.IsValid) return View(model);

            var service = CreateLeagueStaffService();






            if (service.CreateLeagueStaff(model))
            {
             TempData["SaveResult"] = "Your League Staff was created.";
             return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "League Staff could not be created.");

            return View(model);



        }

        public ActionResult Details(int id)
        {
            var svc = CreateLeagueStaffService();
            var model = svc.GetLeagueStaffById(id);

            return View(model);
        }

        private LeagueStaffService CreateLeagueStaffService()

        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LeagueStaffService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLeagueStaffService();
            var detail = service.GetLeagueStaffById(id);
            var model =
                new LeagueStaffEdit
                {
                    LeagueStaffId = detail.LeagueStaffId,
                    LeagueStaffName = detail.LeagueStaffName,
                    LeagueStaffPosition = detail.LeagueStaffPosition
                };
            return View(model);
        }
    }
}