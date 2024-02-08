using FluentValidation;

namespace DevDanApi.Features.Blogs.CreateBlog;

public class CreateBlogValidator : AbstractValidator<CreateBlogCommand>
{
    public CreateBlogValidator()
    {
        RuleFor(x => x.Blog)
            .NotNull()
            .WithMessage("Blog cannot be null");

        RuleFor(x => x.Blog.Title)
            .NotEmpty()
            .WithMessage("Title cannot be empty");

        RuleFor(x => x.Blog.Content)
            .NotEmpty()
            .WithMessage("Content cannot be empty");
    }
}
