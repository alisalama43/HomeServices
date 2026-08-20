using HomeServices.Domain.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.Common.Errors
{
    public static class ApplicationErrors
    {
        // =========================
        // Customer
        // =========================

        public static Error CustomerNotFound =>
            Error.NotFound(
                "ApplicationErrors.Customer.NotFound",
                "Customer does not exist.");

        // =========================
        // Technician
        // =========================

        public static Error TechnicianNotFound =>
            Error.NotFound(
                "ApplicationErrors.Technician.NotFound",
                "Technician does not exist.");

        // =========================
        // Profession
        // =========================

        public static Error ProfessionNotFound =>
            Error.NotFound(
                "ApplicationErrors.Profession.NotFound",
                "Profession does not exist.");

        public static Error ProfessionInactive =>
            Error.Conflict(
                "ApplicationErrors.Profession.Inactive",
                "Profession is not active.");

        // =========================
        // Service
        // =========================

        public static Error ServiceNotFound =>
            Error.NotFound(
                "ApplicationErrors.Service.NotFound",
                "Service does not exist.");

        // =========================
        // Service Request
        // =========================

        public static Error ServiceRequestNotFound =>
            Error.NotFound(
                "ApplicationErrors.ServiceRequest.NotFound",
                "Service request does not exist.");

        public static Error ServiceRequestCustomerMismatch =>
            Error.Conflict(
                "ApplicationErrors.ServiceRequest.CustomerMismatch",
                "The service request does not belong to the current customer.");

        public static Error ServiceRequestAlreadyCancelled =>
            Error.Conflict(
                "ApplicationErrors.ServiceRequest.AlreadyCancelled",
                "Service request is already cancelled.");

        public static Error ServiceRequestCannotBeCancelled =>
            Error.Conflict(
                "ApplicationErrors.ServiceRequest.CannotBeCancelled",
                "Service request cannot be cancelled in its current state.");

        // =========================
        // Matching
        // =========================

        public static Error NoMatchingTechnicians =>
            Error.NotFound(
                "ApplicationErrors.Matching.NoTechnicians",
                "No matching technicians were found for this service request.");

        // =========================
        // Offer
        // =========================

        public static Error OfferNotFound =>
            Error.NotFound(
                "ApplicationErrors.Offer.NotFound",
                "Offer does not exist.");

        public static Error OfferAlreadyExists =>
            Error.Conflict(
                "ApplicationErrors.Offer.AlreadyExists",
                "The technician has already submitted an offer for this service request.");

        public static Error OfferTechnicianMismatch =>
            Error.Conflict(
                "ApplicationErrors.Offer.TechnicianMismatch",
                "The offer does not belong to the current technician.");

        public static Error OfferCustomerMismatch =>
            Error.Conflict(
                "ApplicationErrors.Offer.CustomerMismatch",
                "The offer cannot be accepted by the current customer.");

        // =========================
        // Order
        // =========================

        public static Error OrderNotFound =>
            Error.NotFound(
                "ApplicationErrors.Order.NotFound",
                "Order does not exist.");

        public static Error OrderCustomerMismatch =>
            Error.Conflict(
                "ApplicationErrors.Order.CustomerMismatch",
                "The order does not belong to the current customer.");

        public static Error OrderTechnicianMismatch =>
            Error.Conflict(
                "ApplicationErrors.Order.TechnicianMismatch",
                "The order does not belong to the current technician.");

        // =========================
        // Review
        // =========================

        public static Error ReviewNotFound =>
            Error.NotFound(
                "ApplicationErrors.Review.NotFound",
                "Review does not exist.");

        public static Error ReviewAlreadyExists =>
            Error.Conflict(
                "ApplicationErrors.Review.AlreadyExists",
                "A review has already been submitted for this order.");

        // =========================
        // Complaint
        // =========================

        public static Error ComplaintNotFound =>
            Error.NotFound(
                "ApplicationErrors.Complaint.NotFound",
                "Complaint does not exist.");

        public static Error ComplaintAlreadyExists =>
            Error.Conflict(
                "ApplicationErrors.Complaint.AlreadyExists",
                "An active complaint already exists for this order.");

        public static Error ComplaintOrderMismatch =>
            Error.Conflict(
                "ApplicationErrors.Complaint.OrderMismatch",
                "The complaint does not belong to the specified order.");

        // =========================
        // Authentication / Identity
        // =========================

        public static Error UserNotFound =>
            Error.NotFound(
                "ApplicationErrors.Auth.UserNotFound",
                "User does not exist.");

        public static Error Unauthorized =>
            Error.Conflict(
                "ApplicationErrors.Auth.Unauthorized",
                "The current user is not authorized to perform this operation.");

        public static Error InvalidUserId =>
            Error.Validation(
                "ApplicationErrors.Auth.InvalidUserId",
                "The current user identifier is invalid.");

        // =========================
        // Authorization
        // =========================

        public static Error CustomerAccessDenied =>
            Error.Conflict(
                "ApplicationErrors.Authorization.CustomerAccessDenied",
                "The current customer is not allowed to access this resource.");

        public static Error TechnicianAccessDenied =>
            Error.Conflict(
                "ApplicationErrors.Authorization.TechnicianAccessDenied",
                "The current technician is not allowed to access this resource.");
    }
}
