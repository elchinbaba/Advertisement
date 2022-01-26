#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Advertisement.Data;
using Advertisement.Models;
using Adverts;

namespace Advertisement.Pages.Advertisements
{
    public class IndexModel : PageModel
    {
        private readonly Advertisement.Data.AdvertisementContext _context;
        private readonly IConfiguration Configuration;
        public IndexModel(Advertisement.Data.AdvertisementContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Advertisement.Models.Advertisement> Advertisement { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }

        /*public async Task OnGetAsync()
        {
            Advertisement = await _context.Advertisement.ToListAsync();
        }*/

        //public PaginatedList<Advertisement.Models.Advertisement> Advertisements { get; set; }
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            var ads = from m in _context.Advertisement
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                ads = ads.Where(s => s.Title.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    ads = ads.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    ads = ads.OrderBy(s => s.CreationDate);
                    break;
                case "date_desc":
                    ads = ads.OrderByDescending(s => s.CreationDate);
                    break;
                default:
                    ads = ads.OrderBy(s => s.Title);
                    break;
            }
            /*if (!string.IsNullOrEmpty(SearchString))
            {
                ads = ads.Where(s => s.Title.Contains(SearchString));
            }*/

            var pageSize = Configuration.GetValue("PageSize", 4);
            Advertisement = await PaginatedList<Advertisement.Models.Advertisement>.CreateAsync(ads.AsNoTracking(), pageIndex ?? 1, pageSize);

            //Advertisement = await ads.ToListAsync();
        }
    }
}
