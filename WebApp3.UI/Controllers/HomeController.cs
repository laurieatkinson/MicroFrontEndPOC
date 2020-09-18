using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp3.UI.Models;

namespace WebApp3.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new Page1ViewModel();
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        // This does not work with different port numbers, you'll need to host on separate subdomains
        public IActionResult Index(Page1ViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Update the database
                return RedirectToAction("Page2");
            }
            return PartialView(model);
        }

        public IActionResult Page2()
        {
            var model = new Page2ViewModel();
            return PartialView(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        // This does not work with different port numbers, you'll need to host on separate subdomains
        public IActionResult Page2(Page2ViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Update the database
                return RedirectToAction("Page3");
            }
            return PartialView(model);
        }

        public IActionResult Page3()
        {
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
