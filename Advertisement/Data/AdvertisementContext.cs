#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Advertisement.Models;

namespace Advertisement.Data
{
    public class AdvertisementContext : DbContext
    {
        public AdvertisementContext (DbContextOptions<AdvertisementContext> options)
            : base(options)
        {
        }

        public DbSet<Advertisement.Models.Advertisement> Advertisement { get; set; }
    }
}
