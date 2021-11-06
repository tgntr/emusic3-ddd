using FluentValidation;
using System.Collections.Generic;

namespace SimpleMusicStore.Application.Common
{
    public abstract class PagedQuery
    {
        public int Page { get; set; }
    }

    public class PagedQueryValidator : AbstractValidator<PagedQuery>
    {
        private const int MINIMUM_PAGE = 1;

        public PagedQueryValidator()
        {
            //todo validate total pages?
            RuleFor(a => a.Page)
                .NotNull()
                .GreaterThanOrEqualTo(MINIMUM_PAGE);
        }
    }
}
