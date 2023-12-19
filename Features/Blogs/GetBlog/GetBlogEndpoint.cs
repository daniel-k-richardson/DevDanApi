using Carter;
using MediatR;

namespace DevDanApi.Features.Blogs.GetBlog;

public class GetBlogEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/blogs/{id:int}", async (ISender sender, int id) =>
        {
            var result = await sender.Send(new GetBlogQuery(id));

            return result.Match(
                Succ: blog => blog is null ? Results.NotFound() : Results.Ok(blog),
                Fail: ex => Results.BadRequest(ex.Data.ToString()));
        }).RequireAuthorization();
    }
}

