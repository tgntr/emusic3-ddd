namespace SimpleMusicStore.Application.Catalog.Commands.Add
{
    using FluentValidation;
    using SimpleMusicStore.Application.Catalog.Commands.Add.InformationProvider;
    using SimpleMusicStore.Domain.Catalog;

    public class AddMusicRecordCommandValidator : AbstractValidator<AddMusicRecordCommand>
    {

        public AddMusicRecordCommandValidator()
        {
            RuleFor(a => a.DiscogsUrl)
                .NotNull()
                .Matches(MusicRecordInformationConstants.DISCOGS_URL_PATTERN);

            RuleFor(a => a.Price)
                .NotNull()
                .ExclusiveBetween(CatalogConstants.MIN_PRICE, CatalogConstants.MAX_PRICE);
        }
    }
}
