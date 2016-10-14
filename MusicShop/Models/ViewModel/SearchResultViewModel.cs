using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicShop.Models.ViewModel
{
    public class SearchResultViewModel
    {
        public string Search { get; set; }
        public string Genre { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public List<string> AllGenre { get; set; }
        public Store Store { get; set; }
    }
}