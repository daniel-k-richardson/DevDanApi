using DevDanApi.Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace DevDanApi.Features.Blogs.UpdateBlog;

public sealed record UpdateBlogCommand(int BlogId, Blog blog) : IRequest<Result<Blog>>;
