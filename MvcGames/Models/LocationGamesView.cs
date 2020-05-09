using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcGames.Models
{
    public class LocationGamesView
    {
        public List<Game> Games { get; set; }
        public List<Location> Location { get; set; }
        public SelectList Locations { get; set; }
        public SelectList Genre { get; set; }
        public string GameGenre { get; set; }
        public string LocationCity { get; set; }
        public string SearchString { get; set; }
    }
}
