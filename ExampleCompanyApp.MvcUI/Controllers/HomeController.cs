using ExampleCompanyApp.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExampleCompanyApp.MvcUI.Controllers
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
            var model = new SampleModel { Id = 1, Name = "Sample Model" };

            var x = new ObjectResult(model);
            ObjectResult xa = new ObjectResult(model);
           

            return View(x);
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

        class SampleModel
        {
            public int Id;
            public string Name;
        }
    }
}