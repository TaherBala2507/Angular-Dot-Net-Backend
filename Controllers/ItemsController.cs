using Microsoft.AspNetCore.Mvc;
using testapi.Data;
using Microsoft.EntityFrameworkCore;
using testapi.Models;

namespace testapi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly ItemsDBContext _itemsDbcontext;

        public ItemsController(ItemsDBContext itemsDbcontext)
        {
            this._itemsDbcontext = itemsDbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
             var items = await _itemsDbcontext.Items.ToListAsync(); 

            return Ok(items);
        }
        [HttpPost]
        public async Task<IActionResult> AddItems([FromBody] Item item)
        {
            //item.Id = Guid.NewGuid();
            
            await _itemsDbcontext.Items.AddAsync(item);

            await _itemsDbcontext.SaveChangesAsync();

            return Ok(item);
        }
    }
}
