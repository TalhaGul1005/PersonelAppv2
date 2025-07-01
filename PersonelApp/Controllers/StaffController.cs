using BLL.Data.DataContext;
using BLL.Data.Entities;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PersonelApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StaffController : Controller
    {
        private readonly StaffService _staffService;

        public StaffController(StaffService staffService,Context context)
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
            if(!ModelState.IsValid) { return View(t); }

            bool result = _staffService.AddStaff(t, out string m);

            if (!result)
            {
                ModelState.AddModelError(string.Empty, m);
                return View(t);
            }

            TempData["Message"] = m;
            return RedirectToAction("Index", "Home");
            
        }
        [HttpPost]
        public IActionResult Delete(int StaffId) 
        {
            _staffService.Delete(StaffId);
            return RedirectToAction("Index", "Home");
        }

    }
}





