using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities;

namespace Workify.Infrastructure.DBContext
{
    public class MyDBContext: DbContext
    {

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        public MyDBContext() { }
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

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = Guid.NewGuid(), RoleName = "Admin" },
                new RoleEntity { Id = Guid.NewGuid(), RoleName = "JoobSeeker" },
                new RoleEntity { Id = Guid.NewGuid(), RoleName = "Employer" }
                );

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=workify_db;Username=postgres;Password=lv8iH09Lq4&f1");
            }   
        }
    }
}
