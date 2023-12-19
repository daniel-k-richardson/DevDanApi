using Carter;
using MediatR;

namespace DevDanApi.Features.Blogs.DeleteBlog;

public class DeleteBlogEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/blogs/{blogId:int}", async (int blogId, ISender sender) =>
        {
            var result = await sender.Send(new DeleteBlogCommand(blogId));

            return result.Match(Succ: blog => Results.NoContent(),
                               Fail: ex => Results.BadRequest(ex.Data.ToString()));

        }).RequireAuthorization();
    }
}
