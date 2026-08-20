using HomeServices.Domain.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Technicians
{
    public static class TechnicianError
    {
        public static Error RequiredName => Error.Validation("RequiredName", "The technician name is required.");
        public static Error RequiredPhone => Error.Validation("RequiredPhone", "The technician phone number is required.");
        public static Error RequiredEmail => Error.Validation("RequiredEmail", "The technician email is required.");
        public static Error RequiredBio => Error.Validation("RequiredBio", "The technician bio is required.");
        public static Error InvalidEmail => Error.Validation("InvalidEmail", "The technician email is invalid.");
        public static Error InvalidPhone => Error.Validation("InvalidPhone", "The technician phone number is invalid.");
        public static Error ExistedEmail => Error.Validation("ExistedEmail", "The technician email already exists.");
        public static Error NotFound => Error.Validation("Not Found User");


    }
}
