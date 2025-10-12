using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities;

namespace Workify.Infrastructure.DBContext
{
    public class MyDBContext: DbContext
    {

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }
        public DbSet<UserEntitiy> User {  get; set; }
        public DbSet<UserSettingsEntitiy> UserSettings { get; set; }
        public DbSet<TokenEntity> Token { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntitiy>().HasOne((e) => e.UserSettings).WithOne((e) => e.User).HasForeignKey<UserSettingsEntitiy>((e) => e.UserId).IsRequired();
            modelBuilder.Entity<UserEntitiy>().HasOne((e) => e.Token).WithOne((e) => e.User).HasForeignKey<TokenEntity>((e) => e.UserId).IsRequired();
        }
    }
}
