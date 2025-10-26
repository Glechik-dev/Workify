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
        public DbSet<JobSeekerEntity> JobSeeker {  get; set; }
        public DbSet<JobSeekerSettingsEntity> JobSeekerSettings { get; set; }
        public DbSet<TokenEntity> Token { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<JobSeekerRoleEntity> JobSeekerRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobSeekerEntity>().HasOne((e) => e.JobSeekerSettings).WithOne((e) => e.JobSeeker).HasForeignKey<JobSeekerSettingsEntity>((e) => e.JobSeekerId).IsRequired();
            modelBuilder.Entity<JobSeekerEntity>().HasOne((e) => e.Token).WithOne((e) => e.JobSeeker).HasForeignKey<TokenEntity>((e) => e.JobSeekerId).IsRequired();
            modelBuilder.Entity<JobSeekerEntity>().HasMany((e) => e.JobSeekerRoles).WithOne((e) => e.JobSeeker).HasForeignKey((e) => e.JobSeekerId).IsRequired();
            modelBuilder.Entity<RoleEntity>().HasMany((e) => e.JobSeekerRoles).WithOne((e) => e.Role).HasForeignKey((e) => e.RoleId).IsRequired();

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = Guid.NewGuid(), RoleName = "Admin" },
                new RoleEntity { Id = Guid.NewGuid(), RoleName = "JobSeeker" },
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
