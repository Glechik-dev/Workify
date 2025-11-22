using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities.Employer;
using Workify.Core.Entities.JobSeeker;
using Workify.Core.Entities.Other;
using Workify.Core.Entities.User;

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
        public DbSet<JobSeekerEntity> JobSeeker {  get; set; }
        public DbSet<JobSeekerSettingsEntity> JobSeekerSettings { get; set; }
        public DbSet<EmployerEntity> Employer { get; set; }
        public DbSet<EmployerSettingsEntity> EmployerSettings { get; set; }
        public DbSet<EmployerCompanyEntity> EmployerCompaniy { get; set; }
        public DbSet<TokenEntity> Token { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<UserRoleEntity> UserRole { get; set; }
        public DbSet<VacancyEntity> Vacancy {  get; set; }
        public DbSet<ResumeEntity> Resume { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasOne((e) => e.JobSeeker).WithOne((e) => e.User).HasForeignKey<JobSeekerEntity>((e) => e.UserId).IsRequired();
            modelBuilder.Entity<UserEntity>().HasOne((e) => e.Token).WithOne((e) => e.User).HasForeignKey<TokenEntity>((e) => e.UserId).IsRequired();
            modelBuilder.Entity<UserEntity>().HasMany((e) => e.UserRoles).WithOne((e) => e.User).HasForeignKey((e) => e.UserId).IsRequired();
            modelBuilder.Entity<UserEntity>().HasOne((e) => e.Employer).WithOne((e) => e.User).HasForeignKey<EmployerEntity>((e) => e.UserId).IsRequired();
            modelBuilder.Entity<UserEntity>().HasOne((e) => e.UserSettings).WithOne((e) => e.User).HasForeignKey<UserSettingsEntity>((e) => e.UserId).IsRequired();
            modelBuilder.Entity<JobSeekerEntity>().HasOne((e) => e.JobSeekerSettings).WithOne((e) => e.JobSeeker).HasForeignKey<JobSeekerSettingsEntity>((e) => e.JobSeekerId).IsRequired();
            modelBuilder.Entity<EmployerEntity>().HasOne((e) => e.EmployerSettings).WithOne((e) => e.Employer).HasForeignKey<EmployerSettingsEntity>((e) => e.EmployerId).IsRequired();
            modelBuilder.Entity<RoleEntity>().HasMany((e) => e.JobSeekerRoles).WithOne((e) => e.Role).HasForeignKey((e) => e.RoleId).IsRequired();
            modelBuilder.Entity<EmployerEntity>().HasMany(e => e.Vacancies).WithOne(e => e.Author).HasForeignKey(e => e.AuthorId).IsRequired();
            modelBuilder.Entity<EmployerEntity>().HasMany(e => e.LikedResume).WithMany(e => e.WhoLikes).UsingEntity(t => t.ToTable("EmployerLikedResume"));
            modelBuilder.Entity<EmployerEntity>().HasMany(e => e.DislikedResume).WithMany(e => e.WhoDislikes).UsingEntity(t => t.ToTable("EmployerDislikedResume"));
            modelBuilder.Entity<EmployerEntity>().HasOne(e => e.EmployerCompany).WithOne(e => e.Employer).HasForeignKey<EmployerCompanyEntity>(e => e.EmployerId).IsRequired();
            modelBuilder.Entity<JobSeekerEntity>().HasOne(e => e.Resume).WithOne(e => e.Author).HasForeignKey<ResumeEntity>(e => e.AuthorId).IsRequired();
            modelBuilder.Entity<JobSeekerEntity>().HasMany(e => e.LikedVacancy).WithMany(e => e.WhoLikes).UsingEntity(t => t.ToTable("JobSeekerLikedVacancies"));
            modelBuilder.Entity<JobSeekerEntity>().HasMany(e => e.DislikedVacancy).WithMany(e => e.WhoDislikes).UsingEntity(t => t.ToTable("JobSeekerDislikedVacancies"));


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
