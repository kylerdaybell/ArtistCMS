using Microsoft.EntityFrameworkCore;
using KylerAndBrandonCMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KylerAndBrandonCMS2.Data
{
    public class CmsContext : IdentityDbContext
    {
        public CmsContext(DbContextOptions<CmsContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ParagraphItem>()
                .HasOne<Page>(pi => pi.Page)
                .WithMany(p => p.ParagraphItems)
                .HasForeignKey(pi => pi.PageId);

            modelBuilder.Entity<ImageItem>()
                .HasOne<Page>(ii => ii.Page)
                .WithMany(p => p.imageItems)
                .HasForeignKey(ii => ii.PageId);

            modelBuilder.Entity<GallaryItem>()
                .HasOne<Page>(gi => gi.Page)
                .WithMany(p => p.GallaryItems)
                .HasForeignKey(gi => gi.PageId);

            modelBuilder.Entity<GallaryImage>()
                .HasOne<GallaryItem>(git => git.GallaryItem)
                .WithMany(gim => gim.GallaryImages)
                .HasForeignKey(git => git.GallaryItemID);
        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<ParagraphItem> ParagraphItems { get; set; }
        public DbSet<ImageItem> imageItems { get; set; }
        public DbSet<GallaryItem> GallaryItems { get; set; }
        public DbSet<GallaryImage> GallaryImages { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
