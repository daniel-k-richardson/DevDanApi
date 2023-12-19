using LanguageExt.Common;
using MediatR;

namespace DevDanApi.Features.Common.Validation;
public static class ValidationExtensions
{
    public static MediatRServiceConfiguration AddValidation<TRequest, TResult>(this MediatRServiceConfiguration config) 
        where TRequest : notnull
    {
        return config.AddBehavior<IPipelineBehavior<TRequest, Result<TResult>>, ValidationBehavior<TRequest, TResult>>();
    }
}
