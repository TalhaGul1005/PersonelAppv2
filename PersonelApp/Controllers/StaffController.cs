using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PersonelApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService,Context context)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Staff t)
        {
            try
            {
                _staffService.TAdd(t);
                TempData["Message"] = $"Yeni Kişi Eklendi.";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("TCNo", ex.Message);
                return View(t);
            }
        }
        [HttpPost]
        public IActionResult Delete(int StaffId) 
        {
            _staffService.Delete(StaffId);
            return RedirectToAction("Index", "Home");
        }

    }
}





