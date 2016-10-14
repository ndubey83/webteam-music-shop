using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicShop.Models;
using MusicShop.Service;
using System.Collections.Generic;
using System;


namespace MusicShop.Tests.Service
{
     [TestClass]
    public class FilterTest
    {
         AlbumFilter _filterService;

         [TestInitialize]
         public void TestInitialize() {

             List<Album> mockAlbum = new List<Album>
                   {
                       new Album
                       {
                           Id = 1,
                           Title = "Visible Worlds",
                           Artist = "Conductor",
                           Genre = "New Age",
                           Year = 2000,
                           CoverUrl = "",
                           Tracks = new List<Track>
                           {
                               new Track
                               {
                                   Number = 1,
                                   SongTitle = "Connect",
                                   Length = new TimeSpan(0, 5, 0)
                               },
                               new Track
                               {
                                   Number = 2,
                                   SongTitle = "Life Segments",
                                   Length = new TimeSpan(0, 4, 0)
                               },
                               new Track
                               {
                                   Number = 3,
                                   SongTitle = "Gateways",
                                   Length = new TimeSpan(0, 8, 0)
                               },
                               new Track
                               {
                                   Number = 4,
                                   SongTitle = "Target Me",
                                   Length = new TimeSpan(0, 6, 24)
                               },
                               new Track
                               {
                                   Number = 5,
                                   SongTitle = "Tune In",
                                   Length = new TimeSpan(0, 4, 30)
                               },
                           }
                       },
                       new Album
                       {
                           Id = 2,
                           Title = "The Taste of Swing",
                           Artist = "Andy Williams",
                           Genre = "Swing",
                           Year = 2010,
                           CoverUrl = "",
                           Tracks = new List<Track>()
                       },
                       new Album
                       {
                           Id = 3,
                           Title = "H2O",
                           Artist = "Poland Spring",
                           Genre = "Techno",
                           Year = 1845,
                           CoverUrl = "",
                           Tracks = new List<Track>()
                       },
                       new Album
                       {
                           Id = 4,
                           Title = "Of June",
                           Artist = "Owl City",
                           Genre = "Electronica",
                           Year = 2010,
                           CoverUrl = "",
                           Tracks = new List<Track>()
                       },
                       new Album
                       {
                           Id = 5,
                           Title = "Relections",
                           Artist = "Steve Vai",
                           Genre = "Rock",
                           Year = 2005,
                           CoverUrl = "",
                           Tracks = new List<Track>()
                       },
                       new Album
                       {
                           Id = 6,
                           Title = "Live the Life",
                           Artist = "Jacky Cheung",
                           Genre = "Pop",
                           Year = 2007,
                           CoverUrl = "",
                           Tracks = new List<Track>()
                       },
                   };

             _filterService = new AlbumFilter(mockAlbum);
         }


         [TestMethod]
         public void Filter_Album_Basic() {
             var result = _filterService.Filter("H2O", String.Empty, null, null);

             Assert.AreEqual(result.Count, 1);

             result = _filterService.Filter("H", String.Empty, null, null);
             Assert.AreEqual(result.Count, 3);

         }

         [TestMethod]
         public void Filter_Album_Advance() {
             var result = _filterService.Filter("H", "Techno", null, null);

             Assert.AreEqual(result.Count, 1);

             result = _filterService.Filter(string.Empty, String.Empty, 2010, null);
             Assert.AreEqual(result.Count, 2);

             result = _filterService.Filter(string.Empty, String.Empty, 2005, 2010);
             Assert.AreEqual(result.Count, 4);

             result = _filterService.Filter(string.Empty, String.Empty, null, 2010);
             Assert.AreEqual(result.Count, 6);

         }
    }
}
