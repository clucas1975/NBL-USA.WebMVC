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
    public class PlayersController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Players
        public ActionResult Index()
        {
            var service = new PlayersService();
            var model = service.GetPlayers();
            return View(model);
        }

        //Add method here VVVV
        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayersCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreatePlayersService();

            if (service.CreatePlayers(model))
            {
                TempData["Save Result"] = "Your Player was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Player could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePlayersService();
            var model = svc.GetPlayersById(id);

            return View(model);
        }

        private PlayersService CreatePlayersService()
        {
            var service = new PlayersService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePlayersService();
            var detail = service.GetPlayersById(id);
            var model =
                new PlayersEdit
                {
                    PlayerId = detail.PlayerId,
                    PlayerName = detail.PlayerName,
                    PlayerNumber = detail.PlayerNumber,
                    PlayerPosition = detail.PlayerPosition,
                    PlayerHeight = detail.PlayerHeight,
                    PlayerWeight = detail.PlayerWeight
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlayersEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.PlayerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreatePlayersService();
            if (service.UpdatePlayers(model))
            {
                TempData["Save Result"] = "Your Player was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Player could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePlayersService();
            var model = svc.GetPlayersById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlayersService();
            var model = service.DeletePlayers(id);

            TempData["Save Result"] = "Your Player was deleted";
            return RedirectToAction("Index");
        }
    }


    
}