using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Common.ResultPattern
{
    public enum ErrorKind
    {
        failure,
        unauthorized,
        unexpected,
        forbidden,
        notfound,
        validation,
        conflict,
        badrequest

    }
}
