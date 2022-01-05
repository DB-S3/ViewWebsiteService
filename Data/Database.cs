using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Common;

namespace Data
{
    public class Database : DbContext
    {
        public DbSet<Common.Website> Websites { get; set; }
        public DbSet<Common.Page> Pages { get; set; }

        public DbSet<Common.HTMLObjects> Objects { get; set; }

        public DbSet<Common.Options> Options { get; set; }



        public Database(DbContextOptions<Database> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Common.Page>()
                .HasOne(g => g.Website).WithMany(a => a.Pages).HasForeignKey(g => g.WebsiteId);
            builder.Entity<Common.HTMLObjects>()
                .HasOne(a => a.page)
                .WithMany(b => b.Objects).HasForeignKey(a => a.PageId);
            // Define composite key.
            builder.Entity<Common.HTMLObjects>()
                .HasKey(c => c.key);

            builder.Entity<Common.HTMLObjects>()
                .HasOne(a => a.options)
                .WithOne(b => b.HTMLObjects).HasForeignKey<Common.Options>(a=> a.ObjectId);
            //    builder.Entity<Common.HTMLObjects>()
            //       .HasOne<Common.Options>(s => s.options).WithOne(ad => ad.HTMLObjects);\
            base.OnModelCreating(builder);
        }
    }
}
