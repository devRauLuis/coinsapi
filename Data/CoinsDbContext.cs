using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace coinsapi.Models
{
    public class CoinsDbContext : DbContext
    {
        public TodoContext(DbContextOptions<CoinsContext> options)
            : base(options)
        {
        }

        public DbSet<Coin> Coins { get; set; } = null!;
    }
}