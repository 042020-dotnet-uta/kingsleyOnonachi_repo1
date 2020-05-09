using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGames.Models
{
    public class Location
    {   [Key]
        public int LocationId { get; set; }
        public string City { get; set; }
        public List<Game> Inventory { get; set; }
    }
}
