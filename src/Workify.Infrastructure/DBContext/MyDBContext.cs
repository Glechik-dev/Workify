using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities;

namespace Workify.Infrastructure.DBContext
{
    public class MyDBContext: DbContext
    {

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }
        public DbSet<UserEntity> User {  get; set; }
        public DbSet<UserSettingsEntity> UserSettings { get; set; }
        public DbSet<TokenEntity> Token { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<UserRoleEntity> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasOne((e) => e.UserSettings).WithOne((e) => e.User).HasForeignKey<UserSettingsEntity>((e) => e.UserId).IsRequired();
            modelBuilder.Entity<UserEntity>().HasOne((e) => e.Token).WithOne((e) => e.User).HasForeignKey<TokenEntity>((e) => e.UserId).IsRequired();
            modelBuilder.Entity<UserEntity>().HasMany((e) => e.UserRoles).WithOne((e) => e.User).HasForeignKey((e) => e.UserId).IsRequired();
            modelBuilder.Entity<RoleEntity>().HasMany((e) => e.UserRoles).WithOne((e) => e.Role).HasForeignKey((e) => e.RoleId).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
