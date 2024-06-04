using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TicketMate.Reporting.Domain.Models;

namespace TicketMate.Reporting.Infrastructure
{
    public class ReportingDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public ReportingDbContext(DbContextOptions<ReportingDbContext> options) : base(options)
        {
        }
        public ReportingDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
                var connectionString = "Server=tcp:ptesserver.database.windows.net,1433;Initial Catalog=ptescentral;Persist Security Info=False;User ID=AdminPTES;Password=PTES@admin;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                optionsBuilder.UseSqlServer(connectionString);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasKey(t => t.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}

