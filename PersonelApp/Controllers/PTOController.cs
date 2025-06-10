using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace PersonelApp.Controllers
{
    [Authorize]
    public class PTOController : Controller
    {
        
        

        


        private readonly IPTOService _PTOService;
        private readonly IStaffService _staffService;

        public PTOController(IPTOService pTOService, IStaffService staffService )
        {
            _PTOService = pTOService;
            _staffService = staffService;
        }

        public IActionResult Index()
        {
            var model = new PTOListDto
            {
                PTOList = _PTOService.GetList(),
                StaffList = _staffService.GetList()
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult PTOForm(int id) 
        {
            var model = new PTOCreateDto
            {
                StaffId = id
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult PTOForm(PTOCreateDto dto)
        {
            if(!ModelState.IsValid) { return View(dto); }

            bool result = _PTOService.AddPTO(dto, out string m);

            if (!result)
            {
                ModelState.AddModelError(string.Empty, m);
                return View(dto);
            }

            TempData["Message"] = m;
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult Delete(int id, int StaffId)
        {
            
            _PTOService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
