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
    public class TeamController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Team
        public ActionResult Index()
        {
            var service = new TeamService();
            var model = service.GetTeams();
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
        public ActionResult Create(Team model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateTeamService();

            if (service.CreateTeam(model))
            {
                TempData["SaveResult"] = "Your Team was created.";

                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Team could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamById(id);

            return View(model);
        }

        private TeamService CreateTeamService()
        {
            var service = new TeamService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTeamService();
            var detail = service.GetTeamById(id);
            var model =
                new TeamEdit
                {
                    TeamId = detail.TeamId,
                    TeamOwner = detail.TeamOwner,
                    TeamName = detail.TeamName,
                    TeamLocation = detail.TeamLocation,
                    TeamArena = detail.TeamArena
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, TeamEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TeamId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTeamService();

            if (service.UpdateTeam(model))
            {
                TempData["SaveResult"] = "Your Team was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Team could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTeamService();
            service.DeleteTeam(id);

            TempData["Save Result"] = "Your Team was deleted";
            return RedirectToAction("Index");
        }
    }
}