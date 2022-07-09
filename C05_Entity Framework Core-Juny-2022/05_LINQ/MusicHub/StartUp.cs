namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;

    using Microsoft.EntityFrameworkCore;

    using MusicHub.Data;
    using MusicHub.Initializer;

    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new MusicHubDbContext();
            DbInitializer.ResetDatabase(dbContext);

            var result = ExportSongsAboveDuration(dbContext, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .ToList()
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    Name = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            s.Name,
                            Price = $"{s.Price:F2}",
                            WriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.WriterName)
                        .ToList(),
                    TotalPrice = a.Price
                })
                .OrderByDescending(a => a.TotalPrice)
                .ToList();
                

            var sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int count = 1;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{count++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Select(s => new
                {
                    Name = s.Name,
                    PerfomerFullName = s.SongPerformers
                        .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                        .FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    ProducerName = s.Album.Producer.Name,
                    Duration = s.Duration,
                })
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerfomerFullName)
                .ToList();

            var sb = new StringBuilder();
            int count = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{count++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.PerfomerFullName}");
                sb.AppendLine($"---AlbumProducer: {song.ProducerName}");
                sb.AppendLine($"---Duration: {song.Duration:c}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
