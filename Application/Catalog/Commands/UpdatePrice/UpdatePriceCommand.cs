namespace SimpleMusicStore.Application.Catalog.Commands.UpdatePrice
{
    using Common;
    using MediatR;
    using SimpleMusicStore.Domain.Catalog.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdatePriceCommand : EntityCommand<int>, IRequest<Result>
    {
        public decimal Price { get; set; }

        public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand, Result>
        {
            private readonly ICatalogDomainRepository _inventoryDomainRepository;

            public UpdatePriceCommandHandler(
                ICatalogDomainRepository inventoryDomainRepository)
            {
                _inventoryDomainRepository = inventoryDomainRepository;
            }

            public async Task<Result> Handle(
                UpdatePriceCommand request,
                CancellationToken cancellationToken)
            {
                var musicRecord = await _inventoryDomainRepository.FindMusicRecord(request.Id);

                if (musicRecord == null)
                {
                    //todo error messages class
                    return "Music record does not exist.";
                }

                musicRecord.UpdatePrice(request.Price);

                await _inventoryDomainRepository.Save(musicRecord, cancellationToken);

                return Result.Success;
            }
        }
    }
}
