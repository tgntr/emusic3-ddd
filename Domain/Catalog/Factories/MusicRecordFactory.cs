using SimpleMusicStore.Domain.Catalog.Exceptions;
using SimpleMusicStore.Domain.Catalog.Models;
using SimpleMusicStore.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMusicStore.Domain.Catalog.Factories
{
    internal class MusicRecordFactory : IMusicRecordFactory
    {
        private int _id = default!;
        private string _title = default!;
        private IEnumerable<Artist> _artists = default!;
        private Label _label = default!;
        private DateTime _dateReleased = default!;
        private Genre _genre = default!;
        private AudioFormat _audioFormat = default!;
        private decimal _price = default!;
        private IEnumerable<Track> _tracklist = default!;
        private string _imageUrl = default!;
        private bool _isActive = true;

        public IMusicRecordFactory WithId(int id)
        {
            _id = id;
            return this;
        }

        public IMusicRecordFactory WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public IMusicRecordFactory WithArtists(IEnumerable<ArtistLabelInputModel> artists)
        {
            _artists = artists.Select(a => new Artist(a.Id, a.Name, a.ImageUrl));
            return this;

        }

        public IMusicRecordFactory WithLabel(int id, string name, string imageUrl)
        {
            _label = new Label(id, name, imageUrl);
            return this;
        }

        public IMusicRecordFactory WithReleaseDate(int year)
        {
            const int first = 1;
            _dateReleased = new DateTime(year, first, first);
            return this;
        }

        public IMusicRecordFactory WithGenre(IEnumerable<string> genres, IEnumerable<string> styles)
        {
            _genre = new Genre(genres, styles);
            return this;
        }

        public IMusicRecordFactory WithAudioFormat(string audioFormat)
        {
            _audioFormat = Enumeration.FromName<AudioFormat>(audioFormat);
            return this;
        }

        public IMusicRecordFactory WithPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public IMusicRecordFactory WithTracklist(IEnumerable<TrackInputModel> tracklist)
        {
            _tracklist = tracklist.Select(t => new Track(t.Title, t.Duration, t.AudioUrl));
            return this;
        }

        public IMusicRecordFactory WithImageUrl(string imageUrl)
        {
            _imageUrl = imageUrl;
            return this;
        }

        public IMusicRecordFactory WithStatus(bool isActive)
        {
            _isActive = isActive;
            return this;
        }

        public MusicRecord Build()
        {
            //todo test  == default!
            if (_id == default!)
                throw new InvalidMusicRecordException("Id is required");
            else if (_title == default!)
                throw new InvalidMusicRecordException("Title is required");
            else if (_artists == default!)
                throw new InvalidMusicRecordException("Artist is required");
            else if (_label == default!)
                throw new InvalidMusicRecordException("Label is required");
            else if (_dateReleased == default!)
                throw new InvalidMusicRecordException("Release Date is required");
            else if (_genre == default!)
                throw new InvalidMusicRecordException("Genre is required");
            else if (_audioFormat == default!)
                throw new InvalidMusicRecordException("Audio Format is required");
            else if (_price == default!)
                throw new InvalidMusicRecordException("Price is required");
            else if (_tracklist == default!)
                throw new InvalidMusicRecordException("Track is required");
            else if (_imageUrl == default!)
                throw new InvalidMusicRecordException("Image URL is required");


            return new MusicRecord(
                _id,
                _title,
                _artists,
                _label,
                _dateReleased,
                _genre,
                _audioFormat,
                _price,
                _tracklist,
                _imageUrl,
                _isActive);
        }
    }
}
