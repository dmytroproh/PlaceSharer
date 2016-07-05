using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceSharer.DAL.Entities
{
    public class Place
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public double GeoLong { get; set; }
        public double GeoLat { get; set; }
    }
}
