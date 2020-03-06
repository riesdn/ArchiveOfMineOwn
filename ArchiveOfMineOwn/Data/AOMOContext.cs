using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArchiveOfMineOwn.Models;

namespace ArchiveOfMineOwn.Data {
    public class AOMOContext: DbContext {
        public AOMOContext(DbContextOptions<AOMOContext> options)
            : base(options) {
        }
        
        protected override void OnModelCreating(ModelBuilder model) {

            model.Entity<Author>(e => {
                e.ToTable("Authors");
                e.HasKey(e => e.Id);
                e.Property(e => e.Pseud).HasMaxLength(20).IsRequired();
                e.HasIndex(e => e.Pseud).IsUnique();
                e.Property(e => e.Password).HasMaxLength(20).IsRequired();
                e.Property(e => e.Bio).HasMaxLength(255);
                e.Property(e => e.NumWorks).HasDefaultValue(0);
                e.Property(e => e.NumBookmarks).HasDefaultValue(0);
                e.Property(e => e.TotalHits).HasDefaultValue(0);
                e.Property(e => e.TotalWordCount).HasDefaultValue(0);
                e.Property(e => e.Joined).IsRequired().HasColumnType("date").HasDefaultValueSql("GETDATE()");
            });

            model.Entity<Work>(e => {
                e.ToTable("Works");
                e.HasKey(e => e.Id);
                e.Property(e => e.Title).HasMaxLength(100).IsRequired().HasDefaultValue("Untitled");
                e.Property(e => e.Summary).HasMaxLength(255);
                e.Property(e => e.WordCount).HasDefaultValue(0);
                e.Property(e => e.Hits).HasDefaultValue(0);
                e.Property(e => e.Chapters).HasDefaultValue(1);
                e.Property(e => e.NumComments).HasDefaultValue(0);
                e.Property(e => e.NumKudos).HasDefaultValue(0);
                e.Property(e => e.NumBookmarks).HasDefaultValue(0);
                e.Property(e => e.Published).HasColumnType("date").HasDefaultValueSql("GETDATE()").IsRequired();
                e.Property(e => e.Updated).HasColumnType("date").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            });
        }

        public DbSet<ArchiveOfMineOwn.Models.Author> Authors { get; set; }
        public DbSet<ArchiveOfMineOwn.Models.Work> Works { get; set; }
    }
}
