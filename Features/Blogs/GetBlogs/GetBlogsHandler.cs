using DevDanApi.Domain.Entities;
using DevDanApi.Infrastructure.Data;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevDanApi.Features.Blogs.GetBlogs;

public class GetBlogsHandler : IRequestHandler<GetBlogsQuery, Result<IEnumerable<Blog>>>
{
    private readonly AppDbContext _appDataContext;

    public GetBlogsHandler(AppDbContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public async Task<Result<IEnumerable<Blog>>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        return await _appDataContext.Blogs.ToListAsync(cancellationToken);
    }
}
