using FluentValidation;

namespace DevDanApi.Features.Blogs.DeleteBlog;

public class DeleteBlogValidator : AbstractValidator<DeleteBlogCommand>
{
    public DeleteBlogValidator()
    {
        //RuleFor(x => x.blogId).MustAsync(async (blogId, _) =>
        //{
        //    return await appContext.Blogs.AnyAsync(x => x.Id == blogId);
        //}).WithMessage("That blog does not exist.");
    }
}
