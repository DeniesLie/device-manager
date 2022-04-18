using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts)
        : base(opts) { }

    public DbSet<User> Users { get; set; }
    public DbSet<ProjectMembership> UsersInProjects { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<OS> OSes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectMembership>().HasKey(nameof(ProjectMembership.UserId), nameof(ProjectMembership.ProjectId));
        base.OnModelCreating(modelBuilder);
    }
}
