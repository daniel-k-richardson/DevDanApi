using Carter;
using MediatR;

namespace DevDanApi.Features.Blogs.CreateBlog;

public class CreateBlogEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/blogs", async (CreateBlog blog, ISender sender) =>
        {
            var result = await sender.Send(new CreateBlogCommand(blog));

            return result.Match(Succ: blog => Results.Ok(blog),
                Fail: ex => Results.BadRequest(ex.Data.ToString()));

        }).RequireAuthorization();
    }
}
