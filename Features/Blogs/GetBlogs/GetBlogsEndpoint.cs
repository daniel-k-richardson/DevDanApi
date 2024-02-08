using Carter;
using MediatR;

namespace DevDanApi.Features.Blogs.GetBlogs;

public class GetBlogsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/blogs", async (ISender sender) =>
        {
            var result = await sender.Send(new GetBlogsQuery());

            return result.Match(
                Succ: blogs => Results.Ok(blogs),
                Fail: ex => Results.BadRequest(ex.Data.ToString()));
        });
    }
}
