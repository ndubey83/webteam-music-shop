using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicShop.Models;

namespace MusicShop.Service
{
    public interface IStoreService
    {
        Store GetAllStoreAlbums();
        List<string> GetAllGenre();
        Album GetAlbumById(int id);
    }

    public class StoreService : IStoreService
    {
        Store _allStore;
        List<string> _allGenre;

        public StoreService(Store allStore) {
            _allStore = allStore;
        }
        public Store GetAllStoreAlbums() {
            return _allStore;
        }

        public Album GetAlbumById(int id) {
            return _allStore.Albums.Where(f => f.Id == id).FirstOrDefault();
        }

        public List<string> GetAllGenre() {
            if (_allGenre == null)
                _allGenre = _allStore.Albums.Select(f=> f.Genre).Distinct().ToList();
            return _allGenre;
        }
    }
}