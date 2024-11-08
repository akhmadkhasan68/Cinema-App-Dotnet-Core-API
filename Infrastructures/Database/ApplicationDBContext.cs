using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Infrastructures.Database;

public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Role> Roles { get; set; }
    
    public DbSet<Permission> Permissions { get; set; }
    
    public DbSet<RolePermission> RolePermissions { get; set; }
    
    public DbSet<Genre> Genres { get; set; }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<Facility> Facilities { get; set; }

    public DbSet<Studio> Studios { get; set; }

    public DbSet<StudioFacility> StudioFacilities { get; set; }

    public DbSet<Schedule> Schedules { get; set; }

    public DbSet<PaymentMethod> PaymentMethods { get; set; }

    public DbSet<Ticket> Tickets { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User Email Unique
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();


        // Role Permission Many-to-Many
        modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId);

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId);


        // Studio Facility Many-to-Many
        modelBuilder.Entity<StudioFacility>()
            .HasKey(sf => new { sf.StudioId, sf.FacilityId });

        modelBuilder.Entity<StudioFacility>()
            .HasOne(sf => sf.Studio)
            .WithMany(s => s.StudioFacilities)
            .HasForeignKey(sf => sf.StudioId);

        modelBuilder.Entity<StudioFacility>()
            .HasOne(sf => sf.Facility)
            .WithMany(f => f.StudioFacilities)
            .HasForeignKey(sf => sf.FacilityId);
    }
}
