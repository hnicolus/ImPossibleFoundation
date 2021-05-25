using System;
using FluentValidation;

namespace ImPossibleFoundation.Blog.Queries.GetArticleList
{
    public class GetPaginatedArticleListQueryValidator : AbstractValidator<GetPaginatedArticleListQuery>
    {
        public GetPaginatedArticleListQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}