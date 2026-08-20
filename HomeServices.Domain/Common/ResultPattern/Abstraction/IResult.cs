using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Common.ResultPattern.Abstraction
{
    public interface IResult
    {
         List<Error>? Errors { get; }
         bool IsSuccess { get; }

    }
    public interface IResult<out T> : IResult
    {
        T? Value { get; }
    }
}
