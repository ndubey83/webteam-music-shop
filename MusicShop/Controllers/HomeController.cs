using System;
using MusicShop.Models;
using System.Linq;
using System.Web.Mvc;

namespace MusicShop.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Store());
        }

        [HttpPost]
        public ActionResult Index(string search, string genre, int? fromYear, int? toYear)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Album(int id)
        {
            throw new NotImplementedException();
        }
    }
}