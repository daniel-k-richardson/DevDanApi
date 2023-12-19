
using AutoMapper;
using DevDanApi.Domain.Entities;
using DevDanApi.Infrastructure.Data;
using LanguageExt.Common;
using MediatR;

namespace DevDanApi.Features.Blogs.CreateBlog;

public class CreateBlogHandler : IRequestHandler<CreateBlogCommand, Result<Blog>>
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public CreateBlogHandler(
        AppDbContext appDbContext,
        IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task<Result<Blog>> Handle(
        CreateBlogCommand request,
        CancellationToken cancellationToken)
    {
        var blog = _mapper.Map<Blog>(request.blog);
        await _appDbContext.AddAsync(request.blog, cancellationToken);

        try
        {
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            return new Result<Blog>(ex);
        }

        return blog;
    }
}
