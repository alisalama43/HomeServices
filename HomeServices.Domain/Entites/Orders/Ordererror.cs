using HomeServices.Domain.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Orders
{
    public class Ordererror
    {
        public static Error RequiredOfferId=> Error.Validation("RequiredOfferId", "The offer ID is required.");
        public static Error CompletedOrderCannotBeCancelled => Error.Validation("CompletedOrderCannotBeCancelled", "Cannot cancel a completed order.");
        public static Error CompletedOrderCannotBeConfirmed => Error.Validation("CompletedOrderCannotBeConfirmed", "Cannot confirm a completed order.");
    }
}
