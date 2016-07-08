using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceSharer.BLL.DTO
{
    class PlaceDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public double GeoLong { get; set; }
        public double GeoLat { get; set; }
    }
}
