namespace SimpleMusicStore.Application.Catalog.Commands.UpdatePrice
{
    using FluentValidation;
    using SimpleMusicStore.Application.Catalog.Commands.Add.InformationProvider;
    using SimpleMusicStore.Domain.Catalog;

    public class UpdatePriceCommandValidator : AbstractValidator<UpdatePriceCommand>
    {

        public UpdatePriceCommandValidator()
        {
            RuleFor(a => a.Price)
                .NotNull()
                .ExclusiveBetween(CatalogConstants.MIN_PRICE, CatalogConstants.MAX_PRICE);
        }
    }
}
