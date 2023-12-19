using DevDanApi.Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace DevDanApi.Features.Blogs.GetBlogs;

public sealed record GetBlogsQuery : IRequest<Result<IEnumerable<Blog>>>;
