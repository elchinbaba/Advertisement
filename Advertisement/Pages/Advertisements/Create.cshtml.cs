#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Advertisement.Data;
using Advertisement.Models;

namespace Advertisement.Pages.Advertisements
{
    public class CreateModel : PageModel
    {
        private readonly Advertisement.Data.AdvertisementContext _context;

        public CreateModel(Advertisement.Data.AdvertisementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Advertisement.Models.Advertisement Advertisement { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Advertisement.Add(Advertisement);
            await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");

            if (this.HttpContext.Response.StatusCode == 200) return this.StatusCode(this.HttpContext.Response.StatusCode, "Ad " + this.Advertisement.ID + " has been created successfully.");
            else return this.StatusCode(this.HttpContext.Response.StatusCode, "While creating advertisement " + this.Advertisement.ID + " error occured.");

        }
    }
}
