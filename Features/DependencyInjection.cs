using Carter;
using DevDanApi.Domain.Entities;
using DevDanApi.Features.Blogs.CreateBlog;
using DevDanApi.Features.Blogs.DeleteBlog;
using DevDanApi.Features.Blogs.UpdateBlog;
using DevDanApi.Features.Common.Validation;
using FluentValidation;

namespace DevDanApi.Features;

public static class DependencyInjection
{
    public static IServiceCollection AddFeatures(this IServiceCollection services)
    {

        services.AddValidatorsFromAssembly(typeof(Program).Assembly, ServiceLifetime.Transient);

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(typeof(Program).Assembly)
            .AddValidation<CreateBlogCommand, Blog>()
            .AddValidation<DeleteBlogCommand, bool>()
            .AddValidation<UpdateBlogCommand, Blog>()
            );


        services.AddCarter();

        return services;
    }
}
