using Microsoft.EntityFrameworkCore;
using Web.DAL.Models;

namespace Web.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
            {
                SeedInMemoryDatabase();
            }
        }
        public void Initialize()
        {
            this.Database.Migrate();
        }
        private void SeedInMemoryDatabase()
        {
            var navSeed = SeedData.GetNavigations();
            var errSeed = SeedData.GetErrorStatuses();
            foreach (var nav in navSeed)
            {
                nav.NavLinkId = 0;
            }
            foreach (var err in errSeed)
            {
                err.ErrorStatusId = 0;
            }
            Data_NavLinks.AddRange(navSeed);
            ErrorStatus.AddRange(errSeed);
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
