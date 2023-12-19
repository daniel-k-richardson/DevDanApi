using FluentValidation;

namespace DevDanApi.Features.Blogs.CreateBlog;

public class CreateBlogValidator : AbstractValidator<CreateBlogCommand>
{
    public CreateBlogValidator()
    {
        RuleFor(x => x.blog)
            .NotNull()
            .WithMessage("Blog cannot be null");

        RuleFor(x => x.blog.Title)
            .NotEmpty()
            .WithMessage("Title cannot be empty");

        RuleFor(x => x.blog.Content)
            .NotEmpty()
            .WithMessage("Content cannot be empty");
    }
}
