using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToWriteList.Models;

namespace ToWriteList.Controllers
{
    [EnableCors("MyPolicy")]
    public class IndexController : Controller
    {
        [Authorize(Roles = "admin, user")]
        [Route("Index/Menu")]
        public IActionResult Menu()
        {
            return View();
        }

        [HttpGet("~/")]
        public ActionResult Default()
        {
            return RedirectToAction("Menu");
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
