using Microsoft.EntityFrameworkCore;
using testapi.Models;

namespace testapi.Data
{
    public class ItemsDBContext : DbContext
    {
        public ItemsDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}