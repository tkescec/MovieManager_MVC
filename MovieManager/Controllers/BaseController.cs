using Microsoft.AspNetCore.Mvc;
using MovieManager.Models;

namespace MovieManager.Controllers
{
    public class BaseController : Controller
    {
        private MovieManagerContext db = new();

        internal MovieManagerContext Db { get => db; set => db = value; }

        internal void GetTempData()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
                TempData["Message"] = null;
            }
            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
                TempData["Error"] = null;
            }
        }

        internal IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
