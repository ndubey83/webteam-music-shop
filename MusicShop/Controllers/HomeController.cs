using System;
using MusicShop.Models;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using MusicShop.Models.ViewModel;
using MusicShop.Service;

namespace MusicShop.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            SearchResultViewModel model = new SearchResultViewModel();
            StoreService ss = new StoreService(new Store()); 

            model.Store = ss.GetAllStoreAlbums();
            model.AllGenre = ss.GetAllGenre();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string search, string genre, int? fromYear, int? toYear)
        {
            StoreService ss = new StoreService(new Store());
            SearchResultViewModel model = new SearchResultViewModel();

            var store = ss.GetAllStoreAlbums();
            model.AllGenre = ss.GetAllGenre();

            AlbumFilter albumFilter = new AlbumFilter(store.Albums);
            store.Albums = albumFilter.Filter(search, genre, fromYear, toYear);

            model.Search = search;
            model.Genre = genre;
            model.FromYear = fromYear;
            model.ToYear = toYear;
            model.Store = store;

            return View(model);
        }

        [HttpGet]
        public ActionResult Album(int id)
        {
            StoreService ss = new StoreService(new Store());
            return PartialView("_Album", ss.GetAlbumById(id));
        }
    }
}