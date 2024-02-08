﻿using Carter;
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
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddValidatorsFromAssembly(assembly, ServiceLifetime.Scoped);

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly)
            .AddValidation<CreateBlogCommand, Blog>()
            .AddValidation<DeleteBlogCommand, bool>()
            .AddValidation<UpdateBlogCommand, Blog>()
            );


        services.AddCarter();

        return services;
    }
}
