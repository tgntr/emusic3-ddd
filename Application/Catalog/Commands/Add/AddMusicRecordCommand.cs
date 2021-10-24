namespace SimpleMusicStore.Application.Catalog.Commands.Add
{
    using Common;
    using MediatR;
    using SimpleMusicStore.Application.Catalog.Commands.Add.InformationProvider;
    using SimpleMusicStore.Domain.Catalog.Factories;
    using SimpleMusicStore.Domain.Catalog.Repositories;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddMusicRecordCommand : EntityCommand<int>, IRequest<Result<AddMusicRecordOutputModel>>
    {
        public string DiscogsUrl { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public bool IsActive { get; set; } = true;

        public class AddMusicRecordCommandHandler : IRequestHandler<AddMusicRecordCommand, Result<AddMusicRecordOutputModel>>
        {
            private readonly IMusicRecordInformationProvider _musicRecordInformationProvider;
            private readonly IMusicRecordFactory _musicRecordFactory;
            private readonly ICatalogDomainRepository _inventoryDomainRepository;

            public AddMusicRecordCommandHandler(
                IMusicRecordInformationProvider musicRecordInformationProvider,
                IMusicRecordFactory musicRecordFactory,
                ICatalogDomainRepository inventoryDomainRepository)
            {
                _musicRecordInformationProvider = musicRecordInformationProvider;
                _musicRecordFactory = musicRecordFactory;
                _inventoryDomainRepository = inventoryDomainRepository;
            }

            public async Task<Result<AddMusicRecordOutputModel>> Handle(
                AddMusicRecordCommand request,
                CancellationToken cancellationToken)
            {
                var recordInfo = await _musicRecordInformationProvider.ExtractInformationFromUrl(request.DiscogsUrl);

                if (await _inventoryDomainRepository.IsExistingRecord(recordInfo.Id))
                {
                    return "MusicRecord already exists";
                }

                var musicRecord = _musicRecordFactory
                    .WithId(recordInfo.Id)
                    .WithTitle(recordInfo.Title)
                    .WithArtists(recordInfo.Artists.Select(a => new ArtistLabelInputModel(a.Id, a.Name, a.ImageUrl)))
                    .WithLabel(recordInfo.Label.Id, recordInfo.Label.Name, recordInfo.Label.ImageUrl)
                    .WithReleaseDate(recordInfo.Year)
                    .WithGenre(recordInfo.Genres, recordInfo.Styles)
                    .WithAudioFormat(recordInfo.Format)
                    .WithPrice(request.Price)
                    .WithTracklist(recordInfo.Tracklist.Select(t => new TrackInputModel(t.Title, t.Duration)))
                    .WithImageUrl(recordInfo.ImageUrl)
                    .WithStatus(request.IsActive)
                    .Build();

                await _inventoryDomainRepository.Save(musicRecord, cancellationToken);

                return new AddMusicRecordOutputModel(recordInfo.Id);
            }
        }
    }
}
