using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceSharer.BLL.DTO
{
    public class PlaceDTO
    {
        public string Id { get; set; }
        public double GeoLong { get; set; }
        public double GeoLat { get; set; }
    }
}
