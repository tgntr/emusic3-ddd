namespace SimpleMusicStore.Application.Catalog.Queries.Browse
{
    using FluentValidation;
    using SimpleMusicStore.Domain.Catalog;

    public class SearchCatalogQueryValidator : AbstractValidator<SearchCatalogQuery>
    {
        public SearchCatalogQueryValidator()
        {
            RuleFor(s => s.SearchQuery)
                .NotNull()
                .MinimumLength(CatalogConstants.MIN_STRING_LENGTH);
        }
    }
}
