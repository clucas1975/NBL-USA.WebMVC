using NBL_USA.Data;
using NBL_USA.Models;
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
            var model = new FrontOfficeStaffListItem[0];
            return View(_db.FrontOfficeStaffs.ToList());
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
        public ActionResult Create(FrontOfficeStaff frontOfficeStaff)
        {
            if (ModelState.IsValid)
            {
                _db.FrontOfficeStaffs.Add(frontOfficeStaff);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(frontOfficeStaff);
        }
    }
}