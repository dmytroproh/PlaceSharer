using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceSharer.DAL.Entities
{
    public class Location
    {
        [Key]
        [ForeignKey("Place")]
        public string Id { get; set; }
        public double GeoLong { get; set; }
        public double GeoLat { get; set; }

        public virtual Place Place { get; set; }
    }
}
