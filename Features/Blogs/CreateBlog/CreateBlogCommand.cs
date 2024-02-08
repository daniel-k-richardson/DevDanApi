using DevDanApi.Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace DevDanApi.Features.Blogs.CreateBlog;

public sealed record CreateBlogCommand(Blog Blog) : IRequest<Result<Blog>>;
