using Carter;
using DevDanApi.Features.Blogs.Dtos;
using MediatR;

namespace DevDanApi.Features.Blogs.UpdateBlog;

public class UpdateBlogEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/blogs/{blogId:int}", async (int blogId, BlogDto blog, ISender sender) =>
        {
            var result = await sender.Send(new UpdateBlogCommand(blogId, blog));

            return result.Match(
                Succ: blog => Results.Ok(blog),
                Fail: ex => Results.BadRequest(ex.Data.ToString()));

        }).RequireAuthorization();
    }
}
