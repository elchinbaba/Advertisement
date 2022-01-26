using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace AdvertisementApi.Models
{
    public class AdvertisementContext : DbContext
    {
        public AdvertisementContext(DbContextOptions<AdvertisementContext> options)
            : base(options)
        {
        }
        public DbSet<AdvertisementItem> AdvertiesementItems { get; set; } = null!;
    }
}
