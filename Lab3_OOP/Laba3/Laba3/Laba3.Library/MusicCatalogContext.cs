using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.Library
{
    internal class MusicCatalogContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=C:\\Users\\Lenovo\\Desktop\\SurGU\\3 курс\\ООП 3 курс\\3 лаба\\Laba3\\My_bd\\MusicCatalog.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasIndex(t => t.Id);
            modelBuilder.Entity<Album>().HasIndex(t => t.Id);
            modelBuilder.Entity<Artist>().HasIndex(t => t.Id);


            modelBuilder.Entity<Song>()
                        .HasOne(m => m.Artist)
                        .WithMany(d => d.Songs)
                        .HasForeignKey(m => m.AlbumId);

            modelBuilder.Entity<Album>()
                        .HasOne(m => m.Song)
                        .WithMany(d => d.Album)
                        .HasForeignKey(m => m.SongId);
        }
    }
}
