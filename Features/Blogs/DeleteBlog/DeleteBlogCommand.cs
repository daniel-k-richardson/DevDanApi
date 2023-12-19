using LanguageExt.Common;
using MediatR;

namespace DevDanApi.Features.Blogs.DeleteBlog;

public sealed record DeleteBlogCommand(int blogId) : IRequest<Result<bool>>;
