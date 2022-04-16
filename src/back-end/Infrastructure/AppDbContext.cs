using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts)
        : base(opts) { }

    public DbSet<User> Users { get; set; }
    public DbSet<UserInProject> UsersInProjects { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<OS> OSes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserInProject>().HasKey(nameof(UserInProject.UserId), nameof(UserInProject.ProjectId));
        base.OnModelCreating(modelBuilder);
    }
}
