using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<JobCategory> JobCategories => Set<JobCategory>();
        public DbSet<JobSubCategory> JobSubCategories => Set<JobSubCategory>();

        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserDetail> UserDetails => Set<UserDetail>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Job> Jobs => Set<Job>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<JobCategory>().ToTable("jobcategories");

            modelBuilder.Entity<JobSubCategory>().ToTable("jobsubcategories")
                .HasOne(j => j.JobCategory)
                .WithMany(t => t.JobSubCategories)
                .HasForeignKey(l => l.JobCategoryId);

            modelBuilder.Entity<User>().ToTable("users");

            modelBuilder.Entity<Role>().ToTable("roles")
                .HasMany(r => r.Users)
                .WithMany(r => r.Roles)
                .UsingEntity<Dictionary<string, object>>(
                        "userroles",
                        r => r.HasOne<User>()
                            .WithMany()
                            .HasForeignKey("user_id"),
                        l => l.HasOne<Role>()
                            .WithMany()
                            .HasForeignKey("role_id"),
                        j =>
                        {
                            j.HasKey("user_id", "role_id");
                            j.ToTable("userroles");
                        }
                );

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.ToTable("userdetails");
                entity.HasKey(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithOne(u => u.UserDetail)
                    .HasForeignKey<UserDetail>(d => d.UserId)
                    .HasConstraintName("fk_userdetails_user");
            });

            modelBuilder.Entity<RefreshToken>().ToTable("refreshtokens")
                .HasOne(r => r.User)
                .WithOne(t => t.RefreshToken)
                .HasForeignKey<RefreshToken>(u => u.UserId);

            modelBuilder.Entity<Address>().ToTable("addresses");

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("jobs");
                entity.HasOne(j => j.JobCategory)
                    .WithMany()
                    .HasForeignKey(e => e.JobCategoryId)
                    .HasConstraintName("fk_jobs_job_category");

                entity.HasOne(j => j.JobSubCategory)
                    .WithMany()
                    .HasForeignKey(e => e.JobSubCategoryId)
                    .HasConstraintName("fk_jobs_job_sub_category");

                entity.HasOne(j => j.Address)
                    .WithMany()
                    .HasForeignKey(e => e.AddressId)
                    .HasConstraintName("fk_jobs_address");

            });
        }
    }
}