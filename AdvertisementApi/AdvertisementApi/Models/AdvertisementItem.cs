using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertisementApi.Models
{
    public class AdvertisementItem
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [NotMapped] public string[]? LinkstoPhotos { get; set; }
        public float Price { get; set; }
        [DataType(DataType.Date)] public DateTime? CreationDate { get; set; }
    }
}
