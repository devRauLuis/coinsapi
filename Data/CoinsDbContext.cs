using coinsapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace coinsapi.Data;

public class CoinsDbContext : DbContext
{
    public CoinsDbContext(DbContextOptions<CoinsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Coin> Coins { get; set; } = null!;
}