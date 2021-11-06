namespace SimpleMusicStore.Domain.Catalog.Factories
{
    using Common;
    using SimpleMusicStore.Domain.Catalog.Models;
    using System.Collections.Generic;

    public interface IMusicRecordFactory : IFactory<MusicRecord>
    {
        IMusicRecordFactory WithId(int id);
        IMusicRecordFactory WithTitle(string title);
        IMusicRecordFactory WithArtists(IEnumerable<ArtistLabelInputModel> artists);
        IMusicRecordFactory WithLabel(int id, string name, string imageUrl);
        IMusicRecordFactory WithReleaseDate(int year);
        IMusicRecordFactory WithGenre(IEnumerable<string> genres, IEnumerable<string> styles);
        IMusicRecordFactory WithAudioFormat(string audioFormat);
        IMusicRecordFactory WithPrice(decimal price);
        IMusicRecordFactory WithTracklist(IEnumerable<TrackInputModel> tracklist);
        IMusicRecordFactory WithImageUrl(string imageUrl);
        IMusicRecordFactory WithStatus(bool isActive);
    }

    public class ArtistLabelInputModel
    {
        public ArtistLabelInputModel(int id, string name, string imageUrl)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ImageUrl { get; private set; }
    }

    public class TrackInputModel
    {
        public TrackInputModel(string title, string duration, string? audioUrl = null)
        {
            Title = title;
            Duration = duration;
            AudioUrl = audioUrl ?? default!;
        }

        public string Title { get; private set; }
        public string Duration { get; private set; }
        public string AudioUrl { get; private set; }
    }
}
