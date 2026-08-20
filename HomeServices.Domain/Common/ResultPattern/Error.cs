using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Common.ResultPattern
{
    public readonly record struct Error
    {
        private Error(ErrorKind kind, string description, string code)
        {
            this.kind = kind;
            Description = description;
            Code = code;
        }

        public ErrorKind kind { get; }
        public string Description { get; }
        public string Code { get; }
        public static Error Failure(string code = nameof(Failure), string description = "An error has occurred") => new Error(ErrorKind.failure, description, code);
        public static Error Unauthorized(string code = nameof(Unauthorized), string description = "Unauthorized") => new Error(ErrorKind.unauthorized, description, code);
        public static Error Unexpected(string code = nameof(Unexpected), string description = "Unexpected error") => new Error(ErrorKind.unexpected, description, code);
        public static Error Forbidden(string code = nameof(Forbidden), string description = "Forbidden") => new Error(ErrorKind.forbidden, description, code);
        public static Error NotFound(string code = nameof(NotFound), string description = "Not found") => new Error(ErrorKind.notfound, description, code);
        public static Error Validation(string code = nameof(Validation), string description = "Validation error") => new Error(ErrorKind.validation, description, code);
        public static Error Conflict(string code = nameof(Conflict), string description = "Conflict") => new Error(ErrorKind.conflict, description, code);
        public static Error BadRequest(string code = nameof(BadRequest), string description = "Bad request") => new Error(ErrorKind.badrequest, description, code);
    }
}
