﻿using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace BMSApplication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BMSApplication.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<BMSApplication.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<BMSApplication.Models.Color> Colors { get; set; }

        public System.Data.Entity.DbSet<BMSApplication.Models.Size> Sizes { get; set; }

        public System.Data.Entity.DbSet<BMSApplication.Models.Sell_Price> Sell_Price { get; set; }

        public System.Data.Entity.DbSet<BMSApplication.Models.Courier> Couriers { get; set; }

        public System.Data.Entity.DbSet<BMSApplication.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<BMSApplication.Models.CSCategory> CSCategories { get; set; }

        public System.Data.Entity.DbSet<BMSApplication.Models.Group> Groups { get; set; }

        public System.Data.Entity.DbSet<BMSApplication.Models.Address> Addresses { get; set; }
    }
}