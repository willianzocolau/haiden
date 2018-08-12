using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data
{
    public partial class HaidenDbContext : DbContext
    {
        public HaidenDbContext()
        {
        }

        public HaidenDbContext(DbContextOptions<HaidenDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<FontLinks> FontLinks { get; set; }
        public virtual DbSet<Fonts> Fonts { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Stopwords> Stopwords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=haiden;Username=postgres;Password=@#haiden#@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FontLinks>(entity =>
            {
                entity.HasOne(d => d.FkidFontNavigation)
                    .WithMany(p => p.FontLinks)
                    .HasForeignKey(d => d.FkidFont)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_font_links_font");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasOne(d => d.FkidCategoryNavigation)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.FkidCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_news_cateogy");

                entity.HasOne(d => d.FkidFontLinkNavigation)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.FkidFontLink)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_news_font_link");

                entity.HasOne(d => d.FkidLanguageNavigation)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.FkidLanguage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_news_");
            });

            modelBuilder.Entity<Stopwords>(entity =>
            {
                entity.HasIndex(e => new { e.Stopword, e.FkidLanguage })
                    .HasName("stopwords_stopword_fkid_language_key")
                    .IsUnique();

                entity.HasOne(d => d.FkidLanguageNavigation)
                    .WithMany(p => p.Stopwords)
                    .HasForeignKey(d => d.FkidLanguage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_stopwords_");
            });
        }
    }
}
