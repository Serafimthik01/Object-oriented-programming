// ReSharper disable All

using Microsoft.Data.Sqlite;
using System.Data.Entity;
using System.Data.SQLite;

namespace Laba3.Library;

public static class DbContextTestHelper
{
    public static int AddEntities()
    {
        // Добавляем данные в БД.

        using var context = new MusicCatalogContext();
        context.Database.EnsureCreated();

        var song = new Song { NameSong = "tests" };
        var artist = new Artist { NameArtist = "testar" };
        var album = new Album { NameAlbum = "testal" };

        context.Songs.Add(song);
        context.Albums.Add(album);
        context.Artists.Add(artist);

        return context.SaveChanges();
    }

    public static int UpdateEntities()
    {
        // Обновляем данные в БД.


        using var context = new MusicCatalogContext();
        context.Database.EnsureCreated();

        var songToUpdate = context.Songs.FirstOrDefault(s => s.NameSong == "tests");
        var artistToUpdate = context.Artists.FirstOrDefault(s => s.NameArtist == "testar");
        var albumToUpdate = context.Albums.FirstOrDefault(s => s.NameAlbum == "testal");

        if (songToUpdate != null)
        {
            songToUpdate.NameSong = "tests (upd)";
        }
        if (artistToUpdate != null)
        {
            artistToUpdate.NameArtist = "testar (upd)";
        }
        if (albumToUpdate != null)
        {
            albumToUpdate.NameAlbum = "testal (upd)";
        }

        return context.SaveChanges();
    }

    public static IEnumerable<Song> ReadEntities()
    {
        // Читаем данные из БД.

        using var context = new MusicCatalogContext();
        context.Database.EnsureCreated();

        return context.Songs.Include(s => s.NameSong).ToList();
    }

    public static int RemoveEntities()
    {
        // Удаляем данные в БД.

        using var context = new MusicCatalogContext();
        context.Database.EnsureCreated();

        var songsToDelete = context.Songs.FirstOrDefault(s => s.NameSong == "tests (upd)");
        var artistsToDelete = context.Artists.FirstOrDefault(a => a.NameArtist == "testar (upd)");
        var albumsToDelete = context.Albums.FirstOrDefault(al => al.NameAlbum == "testal (upd)");

        if (songsToDelete != null)
        {
            context.Songs.Remove(songsToDelete);
        }
        if (artistsToDelete != null)
        {
            context.Artists.Remove(artistsToDelete);
        }
        if (albumsToDelete != null)
        {
            context.Albums.Remove(albumsToDelete);
        }

        return context.SaveChanges();
    }
}
