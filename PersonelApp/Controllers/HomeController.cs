using System.Diagnostics;
using BLL.Dto;
using BLL.Repo;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonelApp.Models;

namespace PersonelApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly StaffService _staffService;
        private readonly DepartmentService _departmentService;
        public HomeController(StaffService staffService, DepartmentService departmentService) 
        {
            _staffService = staffService;
            _departmentService = departmentService; 
        }

        public IActionResult Index()
        {
            var model = new StaffListDto
            {
                StaffList = _staffService.GetList(),
                DepartmentList = _departmentService.GetList()
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

