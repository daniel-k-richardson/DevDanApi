using DevDanApi.Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace DevDanApi.Features.Blogs.UpdateBlog;

public class UpdateBlogHandler : IRequestHandler<UpdateBlogCommand, Result<Blog>>
{
    public Task<Result<Blog>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
