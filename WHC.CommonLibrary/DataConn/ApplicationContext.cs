using Microsoft.EntityFrameworkCore;
using WHC.CommonLibrary.Models;
using WHC.CommonLibrary.Models.Address;
using WHC.CommonLibrary.Models.UserInfo;
using WHC.CommonLibrary.Services;

namespace WHC.CommonLibrary.DataConn;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<LoginAttempt> LoginAttempts { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    private readonly CommonFilesService _commonFilesService = new();

    public ApplicationContext()
    {
        
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={_commonFilesService.DbFile}");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(c => c.UserOid);
        modelBuilder.Entity<EmailAddress>()
            .HasKey(c => c.Oid);
        modelBuilder.Entity<Credential>()
            .HasKey(c => c.Oid);
        modelBuilder.Entity<LoginAttempt>()
            .HasKey(c => c.Oid);
        modelBuilder.Entity<Role>()
            .HasKey(c => c.Oid);
        modelBuilder.Entity<UsAddress>()
            .HasKey(c => c.Oid);
        modelBuilder.Entity<NonUSAddress>()
            .HasKey(c => c.Oid);
        modelBuilder.Entity<PhoneNumber>()
            .HasKey(c => c.Oid);
    }
}