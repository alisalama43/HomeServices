using HomeServices.Domain.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Offers
{
    public class OfferErrors
    {
        public static Error RequiredOfferId => Error.Validation("RequiredOfferId", "The offer ID is required.");
        public static Error Expiredoffer => Error.Validation("ExpiredOffer", "The offer has expired.");
    }
}
