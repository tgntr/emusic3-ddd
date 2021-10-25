using FluentValidation;

namespace SimpleMusicStore.Application.Common.Pagination
{
    public abstract class PagedQuery
    {
        public int Page { get; set; }
    }

    public class QueryWithPaginationValidator : AbstractValidator<PagedQuery>
    {
        private const int MINIMUM_PAGE = 1;

        public QueryWithPaginationValidator()
        {
            //todo validate total pages?
            RuleFor(a => a.Page)
                .NotNull()
                .GreaterThanOrEqualTo(MINIMUM_PAGE);
        }
    }
}
