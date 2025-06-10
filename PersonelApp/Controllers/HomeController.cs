using System.Diagnostics;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonelApp.Models;

namespace PersonelApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly IDepartmentService _departmentService;
        public HomeController(IStaffService staffService,IDepartmentService departmentService) { _staffService = staffService; _departmentService = departmentService; }

        public IActionResult Index()
        {
            var model = new StaffListDto
            {
                StaffList = _staffService.GetList(),
                DepartmentList= _departmentService.GetList()
            };
            
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
