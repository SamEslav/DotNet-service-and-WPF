using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ServiceAppSignalR.Models;

namespace ServiceAppSignalR.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
