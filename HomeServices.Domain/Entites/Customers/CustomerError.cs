using HomeServices.Domain.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;


namespace HomeServices.Domain.Entites.Customer
{
    public static class CustomerError
    {
        public static Error NotFound => Error.Validation("Invalid Id","Not Found Customer");
        public static Error RequiredName => Error.Validation("RequiredName", "The customer name is required.");
        public static Error RequiredPhone => Error.Validation("RequiredPhone", "The customer phone number is required.");
        public static Error RequiredEmail => Error.Validation("RequiredEmail", "The customer email is required.");
        public static Error RequiredBio => Error.Validation("RequiredBio", "The customer bio is required.");
        public static Error InvalidEmail => Error.Validation("InvalidEmail", "The customer email is invalid.");
        public static Error InvalidPhone => Error.Validation("InvalidPhone", "The customer phone number is invalid.");
        public static Error ExistedEmail => Error.Validation("ExistedEmail", "The customer email already exists.");
        public static Error RequiredAddress => Error.Validation("RequiredAddress", "The customer address is required.");
        public static Error RequiredCity => Error.Validation("RequiredCity", "The customer city is required.");
        public static Error RequiredActiveStatus => Error.Validation("RequiredActiveStatus", "The customer active status is required.");
    }
}
