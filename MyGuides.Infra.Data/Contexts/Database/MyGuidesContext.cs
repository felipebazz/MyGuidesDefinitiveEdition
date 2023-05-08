using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.Configuration;
using MyGuides.Domain.Entities.Achievements;
using MyGuides.Domain.Entities.Banners;
using MyGuides.Domain.Entities.BannerTypes;
using MyGuides.Domain.Entities.Difficulties;
using MyGuides.Domain.Entities.Games;
using MyGuides.Domain.Entities.Sections; 

namespace MyGuides.Infra.Data.Contexts.Database
{
    public class MyGuidesContext : IdentityUserContext<IdentityUser>
    {
        private readonly IConfiguration _configuration;
        public MyGuidesContext(DbContextOptions<MyGuidesContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<BannerType> BannerTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyGuidesContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UpdateDate") != null))
        //    {
        //        if (entry.State == EntityState.Modified)
        //            entry.Property("UpdateDate").CurrentValue = DateTime.Now;
        //    }

        //    return base.SaveChangesAsync(cancellationToken);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
                    options =>
                    {
                        options.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(15),
                            errorNumbersToAdd: null);
                    });
            }
        }
    }
}
