﻿namespace SimpleMusicStore.Application.Catalog.Commands.Add.InformationProvider
{
    public class MusicRecordInformationConstants
    {
        public const string
            RELEASE = "releases",
            LABEL = "labels",
            ARTIST = "artists",
            MASTER = "masters",
            PARAMETER_SPLITTER = "/",
            VARIOUS_ARTISTS = "Various Artists",
            DEFAULT_IMAGE = @"https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/12in-Vinyl-LP-Record-Angle.jpg/330px-12in-Vinyl-LP-Record-Angle.jpg",
            DISCOGS_URL_PATTERN = @"https:\/\/www\.discogs\.com\/([^\/]+\/)?((release)|(master))\/[0-9]+([^\/]+)?",
            VARIOUS_ARTISTS_ID = "194";
    }
}
