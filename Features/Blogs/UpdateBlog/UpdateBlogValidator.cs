using DevDanApi.Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DevDanApi.Features.Blogs.UpdateBlog;

public class UpdateBlogValidator : AbstractValidator<UpdateBlogCommand>
{
    public UpdateBlogValidator(AppDbContext appDbContext)
    {
        RuleFor(x => x.blog)
            .Must((command, blog) => blog.Id == command.blogId)
            .WithMessage("Blog id does not match BlogId");

        RuleFor(x => x.blogId).MustAsync(async (blogId, _) =>
        {
            return await appDbContext.Blogs.AnyAsync(x => x.Id == blogId);
        }).WithMessage("That blog does not exist.");

    }
}
