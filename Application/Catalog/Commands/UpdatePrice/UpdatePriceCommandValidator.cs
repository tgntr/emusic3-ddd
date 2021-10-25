namespace SimpleMusicStore.Application.Catalog.Commands.UpdatePrice
{
    using FluentValidation;
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
