using GoalkeeperSchoolDataAcess.Models;
using GoalkeeperSchoolDataAcess.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace GoalkeeperSchoolDataAcess.DataAcess.Controlers;

public class GoalkeeperSchoolDBControler : DbContext
{
    public DbSet<DBAccount> Accounts { get; set; }
    public DbSet<DBGoalkeeperProfile> GoalkeeperProfiles { get; set; }
    public DbSet<DBFullName> FullNames { get; set; }

    public GoalkeeperSchoolDBControler(DbContextOptions<GoalkeeperSchoolDBControler> options) : base(options)
    {

    }

    public GoalkeeperSchoolDBControler()
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=goalkeeperSchoolDB;Trusted_Connection=True;");
    }
}