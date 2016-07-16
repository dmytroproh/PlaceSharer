using System;
using System.ComponentModel.DataAnnotations;

namespace PlaceSharer.DAL.Entities
{
    public class Place
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double GeoLong { get; set; }
        public double GeoLat { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        public Place()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
