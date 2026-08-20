using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.Common.Abstract
{
    public interface ICachedQuery
    {
        string CacheKey { get; }
        string[] Tags { get; }
        TimeSpan Expiration { get; }
    }

    public interface ICachedQuery<TResponse> : IRequest<TResponse>, ICachedQuery;
}
