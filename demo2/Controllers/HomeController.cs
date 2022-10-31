using demo2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace demo2.Controllers
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
            return View();
        }
        [HttpGet]
        public IActionResult XacnhanQuenMatKhau()
        {

            return View();
        }
        [HttpGet]
        public IActionResult QuenMatKhau()
        {

            return View();
        }
        [HttpPost]
        public IActionResult QuenMatKhau(string amail,string bSDT)
        {
            var res = Request.Form;
            amail = res["mail"];
            bSDT = res["SDT"];


            return RedirectToRoute("Login");
            
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(string a ,string b)
        {
            var res = Request.Form;
            a = res["mail"];
            b = res["pass"];


            return RedirectToRoute("Page1");
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