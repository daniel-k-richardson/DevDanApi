using DevDanApi.Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace DevDanApi.Features.Blogs.GetBlog;

public sealed record GetBlogQuery(int BlogId) : IRequest<Result<Blog?>>;
