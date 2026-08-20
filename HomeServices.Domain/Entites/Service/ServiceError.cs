using HomeServices.Domain.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Service
{
    public class ServiceError
    {
        public static Error RequiredName => Error.Validation("RequiredName", "The service name is required.");
        public static Error RequiredDescription => Error.Validation("RequiredDescription", "The service description is required.");
        public static Error RequiredStatus => Error.Validation("RequiredStatus", "The service status is required.");
        public static Error CannotCancelCompletedRequest => Error.Validation("CannotCancelCompletedRequest", "Cannot cancel a completed request.");
        public static Error AlreadyCancelled => Error.Validation("AlreadyCancelled", "The request has already been cancelled.");
        public static Error CannotSubmitNonDraftRequest => Error.Validation("CannotSubmitNonDraftRequest", "Cannot submit a request that is not in draft status.");
        public static Error CannotSubmitCancelledRequest => Error.Validation("CannotSubmitCancelledRequest", "Cannot submit a request that has been cancelled.");
        public static Error CannotMatchNonPendingRequest => Error.Validation("CannotMatchNonPendingRequest", "Cannot match a request that is not in pending status.");
        public static Error CannotAcceptOffer => Error.Validation("CannotAcceptOffer", "Cannot accept an offer for a request that is not in pending status.");
    }
}
