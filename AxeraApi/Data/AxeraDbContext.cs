using AxeraApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AxeraApi.Data;

public class AxeraDbContext : DbContext
{
    private readonly DbContextOptions dbContextOptions;

    public AxeraDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        this.dbContextOptions = dbContextOptions;
    }

    public DbSet<Course> Course { get; set; }
    public DbSet<Meeting> Meeting { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<User> User { get; set; }
}
