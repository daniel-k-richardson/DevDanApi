using DevDanApi.Domain.Entities;
using DevDanApi.Infrastructure.Data;
using LanguageExt.Common;
using MediatR;

namespace DevDanApi.Features.Blogs.GetBlog;

public class GetBlogHandler(AppDbContext appDbContext) : IRequestHandler<GetBlogQuery, Result<Blog?>>
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<Result<Blog?>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        return await _appDbContext.Blogs.FindAsync(request.BlogId, cancellationToken);
    }
}
