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
    public class RosterController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Roster
        public ActionResult Index()
        {
            var service = new RosterService();
            var model = service.GetRosters();

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
        public ActionResult Create(Roster model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateRosterService();

            if (service.CreateRoster(model))
            {
                TempData["Save Result"] = "Your Roster was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Roster could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRosterService();
            var model = svc.GetRosterById(id);

            return View(model);
        }
        private RosterService CreateRosterService()
        {
            var service = new RosterService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRosterService();
            var detail = service.GetRosterById(id);
            var model =
                new RosterEdit
                {
                    RosterId = detail.RosterId,
                    CoachName = detail.CoachName,
                    AssistantCoachName = detail.AssistantCoachName,
                    StillActive = detail.StillActive,
                    TeamId = detail.TeamId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RosterEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.RosterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateRosterService();
            if (service.UpdateRoster(model))
            {
                TempData["Save Result"] = "Your Roster was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Roster could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRosterService();
            var model = svc.GetRosterById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRosterService();
            var model = service.DeleteRoster(id);

            TempData["Save Result"] = "Your Roster was deleted.";
            return RedirectToAction("Index");
        }
    }
}