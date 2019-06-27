using Core21OptionsPatternExample.Config;
using Core21OptionsPatternExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Core21OptionsPatternExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptionsSnapshot<MySettings> _mySettings;

        public HomeController(IOptionsSnapshot<MySettings> mySettings)
        {
            _mySettings = mySettings;
        }

        public IActionResult Index()
        {
            var configValue = _mySettings.Value;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
