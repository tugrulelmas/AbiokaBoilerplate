﻿using System.Net;

namespace AbiokaBoilerplate.Infrastructure.Common.Exceptions
{
    public class DenialException : ApiException
    {
        public DenialException(string errorCode, params object[] parameters)
            : this(HttpStatusCode.BadRequest, errorCode, parameters) {
        }

        public DenialException(HttpStatusCode statusCode, string errorCode, params object[] parameters)
            : base(errorCode ) {
            ContentValue = new { ErrorCode = errorCode, Parameters = parameters };
            StatusCode = statusCode;
            ExtraHeaders.Add("Status-Reason", "validation-failed");
        }
    }
}