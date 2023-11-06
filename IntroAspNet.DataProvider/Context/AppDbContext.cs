using IntroAspNet.Domain.Entities.Concretes;
using IntroAspNet.Domain.Entities.Concretes.AppUser;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IntroAspNet.DataProvider.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        protected AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
