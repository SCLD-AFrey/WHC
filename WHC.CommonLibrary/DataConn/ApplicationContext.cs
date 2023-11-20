using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WHC.CommonLibrary.Models;
using WHC.CommonLibrary.Models.Address;
using WHC.CommonLibrary.Models.Login;
using WHC.CommonLibrary.Models.UserInfo;
using WHC.CommonLibrary.Services;

namespace WHC.CommonLibrary.DataConn;

public class ApplicationContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Role>? Roles { get; set; }
    
    private CommonFilesService _commonFilesService {get; set; }

    private ILogger<ApplicationContext> m_logger { get; set; }

    public ApplicationContext()
    {
        m_logger = new Logger<ApplicationContext>(new LoggerFactory());
        _commonFilesService = new CommonFilesService();
        m_logger.LogInformation("Application Context Initialized");
    }

    public ApplicationContext(ILogger<ApplicationContext> p_logger, CommonFilesService p_commonFilesService)
    {
        m_logger = p_logger;
        _commonFilesService = p_commonFilesService;
        m_logger.LogInformation("Application Context Initialized");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={_commonFilesService.DbFile}");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(c => c.UserOid);
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
        modelBuilder.Entity<EmailAddress>()
            .HasKey(c => c.Oid);
        modelBuilder.Entity<Address>()
            .HasKey(c => c.Oid);
    }
}