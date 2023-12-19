using DevDanApi.Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace DevDanApi.Features.Blogs.CreateBlog;

public sealed record CreateBlogCommand(CreateBlog blog) : IRequest<Result<Blog>>;
