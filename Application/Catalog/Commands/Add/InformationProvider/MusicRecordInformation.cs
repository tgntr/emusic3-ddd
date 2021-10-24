using System.Collections.Generic;
using System.Linq;

namespace SimpleMusicStore.Application.Catalog.Commands.Add.InformationProvider
{
    public class MusicRecordInformation : GeneralInformation
    {
        //todo test private set
        public string Title { get; private set; } = default!;
        public IEnumerable<ArtistLabelInformation> Artists { get; private set; } = default!;
        public IEnumerable<ArtistLabelInformation> Labels { private get; set; } = default!;
        public int Year { get; private set; }
        public IEnumerable<string> Genres { get; private set; } = default!;
        public IEnumerable<string> Styles { get; private set; } = default!;
        public IEnumerable<FormatInformation> Formats { private get; set; } = default!;
        public IEnumerable<TrackInformation> Tracklist { get; private set; } = default!;
        public string Format => Formats.First().Name;
        public ArtistLabelInformation Label => Labels.First();
    }

    public class ArtistLabelInformation : GeneralInformation
    {
        public string Name { get; private set; } = default!;
    }

    public abstract class GeneralInformation
    {
        public int Id { get; private set; }
        public IEnumerable<ImageInformation> Images { private get; set; } = default!;
        public string ImageUrl => Images.FirstOrDefault()?.Uri ?? MusicRecordInformationConstants.DEFAULT_IMAGE;
    }

    public class FormatInformation
    {
        public string Name { get; private set; } = default!;
    }

    public class TrackInformation
    {
        public string Title { get; private set; } = default!;
        public string Duration { get; private set; } = default!;
        public string Type_ { get; private set; } = default!;
    }

    public class ImageInformation
    {
        public string Uri { get; private set; } = default!;
    }
}