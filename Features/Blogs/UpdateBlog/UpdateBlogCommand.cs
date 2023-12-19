using DevDanApi.Features.Blogs.Dtos;
using LanguageExt.Common;
using MediatR;

namespace DevDanApi.Features.Blogs.UpdateBlog;

public sealed record UpdateBlogCommand(int blogId, BlogDto blog) : IRequest<Result<BlogDto>>;
