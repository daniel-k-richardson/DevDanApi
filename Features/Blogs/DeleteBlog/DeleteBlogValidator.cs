using DevDanApi.Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DevDanApi.Features.Blogs.DeleteBlog;

public class DeleteBlogValidator : AbstractValidator<DeleteBlogCommand>
{
    public DeleteBlogValidator(AppDbContext appContext)
    {
        RuleFor(x => x.blogId).MustAsync(async (blogId, _) =>
        {
            return await appContext.Blogs.AnyAsync(x => x.Id == blogId);
        }).WithMessage("That blog does not exist.");
    }
}
