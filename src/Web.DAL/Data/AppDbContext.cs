using Microsoft.EntityFrameworkCore;
using Web.DAL.Models;

namespace Web.DAL.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public void Initialize()
        {
            this.Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Data_NavLink>().HasData(SeedData.GetNavigations());
            modelBuilder.Entity<ErrorStatus>().HasData(SeedData.GetErrorStatuses());

            modelBuilder.Entity<Data_NavLink>()
                .HasMany(n => n.ChildNavLinks)
                .WithOne(n => n.ParentNavLink)
                .HasForeignKey(n => n.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Document>()
                .Ignore(x => x.Data);

        }

        public DbSet<Data_NavLink> Data_NavLinks { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ErrorStatus> ErrorStatus { get; set; }
        public DbSet<AppError> AppErrors { get; set; }
    }
}
