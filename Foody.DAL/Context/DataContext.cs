using Foody.CORE.Entities;
using Foody.CORE.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Context
{
    public class DataContext:IdentityDbContext<ApplicationUser>
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=202-3\\SQLDERS;Database=FoodyDB;Integrated Security=true;TrustServerCertificate=true");
        //}

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        //FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();


            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasColumnType("varchar(30)")
                .HasAnnotation("Display", "Açıklama");

            modelBuilder.Entity<Product>()
                .Property(p => p.ListPrice)
                .HasColumnType("decimal(6,2)");
            #endregion

            #region Category
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);
            #endregion

        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Mail> Mails { get; set; }
    }
}
