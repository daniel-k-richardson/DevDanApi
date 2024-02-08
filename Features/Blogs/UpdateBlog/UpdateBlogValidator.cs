using FluentValidation;

namespace DevDanApi.Features.Blogs.UpdateBlog;

public class UpdateBlogValidator : AbstractValidator<UpdateBlogCommand>
{
    public UpdateBlogValidator()
    {
        RuleFor(x => x.blog)
            .Must((command, blog) => blog.Id == command.BlogId)
            .WithMessage("Blog id does not match BlogId");

        //RuleFor(x => x.blog).MustAsync(async (blog, cancelToken) =>
        //{
        //    return await appDbContext.Blogs.AnyAsync(x => x.Id == blog.Id, cancelToken);
        //}).WithMessage("That blog does not exist.");

    }
}
