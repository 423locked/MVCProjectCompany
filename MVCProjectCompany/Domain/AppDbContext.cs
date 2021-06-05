using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCProjectCompany.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProjectCompany.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityBuilder>().HasData(new IdentityRole
            {
                // Id of the admin ROLE
                Id = "ae88094b-003c-49cf-8461-9a7cae33bf59",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityBuilder>().HasData(new IdentityUser
            {
                // id of the admin USER
                Id = "eccd7b76-c75f-4e9f-8f03-9aa7447bc141",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "oddnetofficial@gmail.com",
                NormalizedEmail = "ODDNETOFFICIAL@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "mypass123"),
                SecurityStamp = ""
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                // Linking the admin ROLE with admin USER
                RoleId = "ae88094b-003c-49cf-8461-9a7cae33bf59",
                UserId = "eccd7b76-c75f-4e9f-8f03-9aa7447bc141"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("3e9ad4ce-3a32-4ab6-923e-e66513b1d8d0"),
                CodeWord = "PageIndex",
                Title = "Index"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("8ed105d0-059c-424d-8d64-b83518f781e1"),
                CodeWord = "PageServices",
                Title = "Our services"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("338df90e-9c1f-46ab-a377-adb5efe4eb64"),
                CodeWord = "PageContacts",
                Title = "Our contacts"
            });
        }
    }
}
