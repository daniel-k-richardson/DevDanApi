
using DevDanApi.Domain.Entities;
using DevDanApi.Infrastructure.Data;
using LanguageExt.Common;
using MediatR;

namespace DevDanApi.Features.Blogs.CreateBlog;

public class CreateBlogHandler : IRequestHandler<CreateBlogCommand, Result<Blog>>
{
    private readonly AppDbContext _appDbContext;

    public CreateBlogHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Result<Blog>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        _appDbContext.Add(request.blog);

        try
        {
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            return new Result<Blog>(ex);
        }
        
        return request.blog;

    }
}
