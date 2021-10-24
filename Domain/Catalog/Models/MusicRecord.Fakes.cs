namespace SimpleMusicStore.Domain.Catalog.Models
{
    using Bogus;
    using FakeItEasy;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MusicRecordFakes
    {
        public class MusicRecordDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(MusicRecord);

            public object? Create(Type type) => Data.GenerateFakeMusicRecord();

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static int validFakeId = 1;
            public static string validFakeTitle = "MusicRecord";
            public static IEnumerable<Artist> validFakeArtists = new List<Artist> { new Artist(validFakeId, "Artist", "https://image.url/image.jpg") };
            public static Label validFakeLabel = new Label(validFakeId, "Label", "https://image.url/image.jpg");
            public static DateTime validFakeDateReleased = DateTime.UtcNow;
            public static Genre validFakeGenre = new Genre(new List<string> { "electronic" }, new List<string> { "minimal", "techno" });
            public static AudioFormat validFakeAudioFormat = AudioFormat.Vinyl;
            public static decimal validFakePrice = 1;
            public static IEnumerable<Track> validFakeTracklist = new List<Track> { new Track("track", "10:00", "https://audio.url/audio.mp3") };
            public static string validFakeImageUrl = "https://image.url/image.jpg";

            public static string invalidFakeString = string.Empty;
            public static IEnumerable<Artist> invalidFakeArtists = new List<Artist>();
            public static DateTime invalidFakeDateReleased = new DateTime(1800, 1, 1);
            public static IEnumerable<string> invalidFakeStringCollection = new List<string>();
            public static decimal invalidFakePrice = 0;
            public static IEnumerable<Track> invalidFakeTracklist = new List<Track>();
            public static string invalidFakeImageUrl = "https://imageurl/image.jpg";
            public static IEnumerable<MusicRecord> GetCarAds(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(i => GenerateFakeMusicRecord(i))
                    .Concat(Enumerable
                        .Range(count + 1, count * 2)
                        .Select(i => GenerateFakeMusicRecord(i, true)))
                    .ToList();

            public static MusicRecord GenerateFakeMusicRecord(int id = 1, bool isActive = true)
            {
                return new Faker<MusicRecord>()
                    .CustomInstantiator(f => new MusicRecord(
                        id,
                        validFakeTitle,
                        validFakeArtists,
                        validFakeLabel,
                        validFakeDateReleased,
                        validFakeGenre,
                        validFakeAudioFormat,
                        validFakePrice,
                        validFakeTracklist,
                        validFakeImageUrl,
                        isActive))
                    .Generate();
            }
        }
    }
}
