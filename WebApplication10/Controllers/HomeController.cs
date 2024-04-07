using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(ConsultationRequest model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View("Index", model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
