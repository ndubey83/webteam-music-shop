using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicShop.Models;

namespace MusicShop.Service
{
    public interface IFilter
    {
        List<Album> Filter(string search, string genre, int? fromYear, int? toYear);
    }

    public class AlbumFilter : IFilter
    {
        private List<Album> _albums;
        public AlbumFilter(List<Album> albums) {
            _albums = albums;
        }
        public List<Album> Filter(string search, string genre, int? fromYear, int? toYear) {
            IEnumerable<Album> filteredAlbums = _albums;
            if (!string.IsNullOrWhiteSpace(search)) {
                filteredAlbums = filteredAlbums.Where(f => f.Title.ToLower().Contains(search.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(genre) && genre != "Select a Genre") {
                filteredAlbums = filteredAlbums.Where(f => f.Genre == genre);
            }
            if (fromYear.HasValue || toYear.HasValue) {
                if (fromYear.HasValue)
                    filteredAlbums = filteredAlbums.Where(f => f.Year >= fromYear.Value);
                if (toYear.HasValue)
                    filteredAlbums = filteredAlbums.Where(f => f.Year <= toYear.Value);
            }

            return filteredAlbums.ToList();
        }
    }
}