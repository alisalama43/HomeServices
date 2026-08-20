using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Common
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
