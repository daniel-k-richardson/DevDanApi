using Carter;
using DevDanApi.Domain.Entities;
using MediatR;

namespace DevDanApi.Features.Blogs.UpdateBlog;

public class UpdateBlogEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/blogs/{blogId:int}", async (int blogId, Blog blog, ISender sender) =>
        {
            var result = await sender.Send(new UpdateBlogCommand(blogId, blog));

            return result.Match(
                Succ: blog => Results.Ok(blog),
                Fail: ex => Results.BadRequest(ex.Data.ToString()));

        });
    }
}
