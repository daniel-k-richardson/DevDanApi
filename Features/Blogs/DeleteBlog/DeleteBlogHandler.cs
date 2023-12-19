using DevDanApi.Domain.Entities;
using DevDanApi.Infrastructure.Data;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevDanApi.Features.Blogs.DeleteBlog;

public class DeleteBlogHandler(AppDbContext appDbContext) : IRequestHandler<DeleteBlogCommand, Result<bool>>
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<Result<bool>> Handle(
        DeleteBlogCommand request,
        CancellationToken cancellationToken)
    {
        Blog blog = await _appDbContext.Blogs.FirstAsync(x => x.Id == request.blogId, cancellationToken);
        _appDbContext.Blogs.Remove(blog);

        try
        {
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            return new Result<bool>(ex);
        }

        return true;
    }
}