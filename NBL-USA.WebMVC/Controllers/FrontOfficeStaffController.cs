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
    public class FrontOfficeStaffController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: FrontOfficeStaff
        public ActionResult Index()
        {
            var service = new FrontOfficeStaffService();
            var model = service.GetFrontOfficeStaffs();
            return View(model);
        }

        //Add method here VVVV
        //GET
        public ActionResult Create()
        {
            return View();
        }

        //Add code here vvvv
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FrontOfficeStaff model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateFrontOfficeStaffService();

            if (service.CreateFrontOfficeStaff(model))
            {
                TempData["SaveResult"] = "Your Front Office Staff was created.";//TempData removes info after it's accessed.


                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Front Office Staff could not be created.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateFrontOfficeStaffService();
            var model = svc.GetFrontOfficeStaffById(id);

            return View(model);
        }

        private FrontOfficeStaffService CreateFrontOfficeStaffService()
        {
            var service = new FrontOfficeStaffService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFrontOfficeStaffService();
            var detail = service.GetFrontOfficeStaffById(id);
            var model =
                new FrontOfficeStaffEdit
                {
                    FrontOfficeStaffId = detail.FrontOfficeStaffId,
                    TeamGeneralManagerName = detail.TeamGeneralManagerName,
                    AcademicAdvisorName = detail.AcademicAdvisorName,
                    DirectorOfBasketballOperationsName = detail.DirectorOfBasketballOperationsName
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FrontOfficeStaffEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.FrontOfficeStaffId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFrontOfficeStaffService();

            if (service.UpdateFrontOfficeStaff(model))
            {
                TempData["SaveResult"] = "Your Front Office Staff was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Front Office Staff could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFrontOfficeStaffService();
            var model = svc.GetFrontOfficeStaffById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFrontOfficeStaffService();
            service.DeleteFrontOfficeStaff(id);

            TempData["Save Result"] = "Your Front Office Staff was deleted";
            return RedirectToAction("Index");
        }
    }
}