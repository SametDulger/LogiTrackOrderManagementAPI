using LogiTrackAPI.Data;
using LogiTrackAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LogiTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly LogiTrackContext _context;
        private readonly IMemoryCache _cache;

        public InventoryController(LogiTrackContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetInventory()
        {
            const string cacheKey = "inventoryList";

            if (!_cache.TryGetValue(cacheKey, out List<InventoryItem>? inventory))
            {
                inventory = await _context.InventoryItems.AsNoTracking().ToListAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30));

                _cache.Set(cacheKey, inventory, cacheEntryOptions);
            }

            return Ok(inventory);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<InventoryItem>> AddInventoryItem([FromBody] InventoryItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();

            _cache.Remove("inventoryList"); // Invalidate cache

            return CreatedAtAction(nameof(GetInventory), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteInventoryItem(int id)
        {
            var item = await _context.InventoryItems.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.InventoryItems.Remove(item);
            await _context.SaveChangesAsync();

            _cache.Remove("inventoryList"); // Invalidate cache

            return NoContent();
        }
    }
}
