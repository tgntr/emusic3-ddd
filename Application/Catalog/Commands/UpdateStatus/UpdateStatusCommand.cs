namespace SimpleMusicStore.Application.Catalog.Commands.UpdateStatus
{
    using Common;
    using MediatR;
    using SimpleMusicStore.Domain.Catalog.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateStatusCommand : EntityCommand<int>, IRequest<Result>
    {
        public bool IsActive { get; set; }

        public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand, Result>
        {
            private readonly ICatalogDomainRepository _inventoryDomainRepository;

            public UpdateStatusCommandHandler(
                ICatalogDomainRepository inventoryDomainRepository)
            {
                _inventoryDomainRepository = inventoryDomainRepository;
            }

            public async Task<Result> Handle(
                UpdateStatusCommand request,
                CancellationToken cancellationToken)
            {
                //todo abstract this part
                var musicRecord = await _inventoryDomainRepository.FindMusicRecord(request.Id);

                if (musicRecord == null)
                {
                    //todo error messages class
                    return "Music record does not exist.";
                }

                musicRecord.UpdateStatus(request.IsActive);

                await _inventoryDomainRepository.Save(musicRecord, cancellationToken);

                return Result.Success;
            }
        }
    }
}
