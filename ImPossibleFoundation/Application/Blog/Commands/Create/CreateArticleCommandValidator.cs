using System;
using FluentValidation;

namespace ImPossibleFoundation.Blog
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title Cannot be Empty")
            .MinimumLength(10).WithMessage("Title should be greater than 5 Characters");
            RuleFor(x => x.Cover).NotEmpty().WithMessage("Cover Image is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Article subtitle is required");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Article Content cannot be empty");
        }
    }
}