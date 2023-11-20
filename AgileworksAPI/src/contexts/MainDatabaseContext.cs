using AgileworksAPI.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace AgileworksAPI.DatabaseContexts;
public class MainDatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "agileworks");

    }
    public MainDatabaseContext(DbContextOptions<MainDatabaseContext> options) : base(options) { }

    // Ticket
    public DbSet<Ticket> Tickets { get; set; } = null!;
}