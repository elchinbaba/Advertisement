#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdvertisementApi.Models;

namespace AdvertisementApi.Controllers
{
    [Route("api/AdvertisementItems")]
    [ApiController]
    public class AdvertisementItemsController : ControllerBase
    {
        private readonly AdvertisementContext _context;

        public AdvertisementItemsController(AdvertisementContext context)
        {
            _context = context;
        }

        // GET: api/AdvertisementItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdvertisementItem>>> GetAdvertiesementItems()
        {
            return await _context.AdvertiesementItems.ToListAsync();
        }

        // GET: api/AdvertisementItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdvertisementItem>> GetAdvertisementItem(long id)
        {
            var advertisementItem = await _context.AdvertiesementItems.FindAsync(id);

            if (advertisementItem == null)
            {
                return NotFound();
            }

            return advertisementItem;
        }

        // PUT: api/AdvertisementItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvertisementItem(long id, AdvertisementItem advertisementItem)
        {
            if (id != advertisementItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(advertisementItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertisementItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AdvertisementItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdvertisementItem>> PostAdvertisementItem(AdvertisementItem advertisementItem)
        {
            _context.AdvertiesementItems.Add(advertisementItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetAdvertisementItem", new { id = advertisementItem.Id }, advertisementItem);
            return CreatedAtAction(nameof(GetAdvertisementItem), new { id = advertisementItem.Id }, advertisementItem);
        }

        // DELETE: api/AdvertisementItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvertisementItem(long id)
        {
            var advertisementItem = await _context.AdvertiesementItems.FindAsync(id);
            if (advertisementItem == null)
            {
                return NotFound();
            }

            _context.AdvertiesementItems.Remove(advertisementItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdvertisementItemExists(long id)
        {
            return _context.AdvertiesementItems.Any(e => e.Id == id);
        }
    }
}
