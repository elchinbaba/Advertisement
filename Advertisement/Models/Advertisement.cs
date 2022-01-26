using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advertisement.Models
{
    public class Advertisement
    {
        public int ID { get; set; }
        [StringLength(200)]  public string Title { get; set; } = string.Empty;
        [StringLength(1000)]  public string? Description { get; set; }
        //[NotMapped] public string[]? LinkstoPhotos { get; set; }
        public string Link1 { get; set; } = string.Empty;
        public string? Link2 { get; set; }
        public string? Link3 { get; set; }
        [Column(TypeName = "decimal(18, 2)")]  public decimal Price { get; set; }
        [Display(Name = "Create Date")] [DataType(DataType.Date)] public DateTime? CreationDate { get; set; }
    }
}
