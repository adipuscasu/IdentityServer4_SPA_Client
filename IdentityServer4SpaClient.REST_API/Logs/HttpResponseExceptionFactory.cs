using IdentityServer4SpaClient.DataModels.Common;
using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4SpaClient.REST_API.Logs
{
    /// <summary>
    /// Factory class that provides a way to build HttpResponseExceptions
    /// </summary>
    public static class HttpResponseExceptionFactory
    {
        /// <summary>
        /// Creates a friendly http error for an unhandled exception
        /// Obfuscates exception details like stack trace
        /// </summary>
        /// <param name="exception">Caught exception to be forwarded</param>
        /// <returns>500 - Interval server error</returns>
        public static ActionResult CreateFriendlyException(Exception exception)
        {
            var errorMessage = "ERRORS.UNKNOWN_ERROR";

            return CreateException(HttpStatusCode.InternalServerError, errorMessage);
        }

        /// <summary>
        /// Creates a detailed http error for an unhandled exception
        /// Includes full exception message
        /// </summary>
        /// <param name="exception">Caught exception to be forwarded</param>
        /// <returns>500 - Interval server error</returns>
        public static ActionResult CreateDetailedException(Exception exception)
        {
            var errorMessage = BuildErrorMessage(exception);

            return CreateException(HttpStatusCode.InternalServerError, errorMessage);
        }

        /// <summary>
        /// Create a custom http exception.
        /// </summary>
        /// <param name="appException">Caught exception to be forwarded</param>
        /// <returns></returns>
        public static ActionResult CreateException(AppException appException)
        {
            var errorMessage = BuildErrorMessage(appException);

            var statusCode = GetStatusCodeFromType(appException);

            return CreateException(statusCode, errorMessage);
        }

        /// <summary>
        /// Create a custom http exception.
        /// </summary>
        /// <param name="httpStatusCode">Http status code</param>
        /// <param name="message">Error message</param>
        /// <returns>Http error</returns>
        private static ActionResult CreateException(HttpStatusCode httpStatusCode, string message)
        {
            return null;
        }

        private static HttpStatusCode GetStatusCodeFromType(AppException appException)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            switch (appException.ExceptionType)
            {
                case AppExceptionType.Client:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case AppExceptionType.Authorization:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                case AppExceptionType.Authentication:
                    statusCode = HttpStatusCode.Forbidden;
                    break;
                case AppExceptionType.Server:
                case AppExceptionType.Wtf:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            return statusCode;
        }

        private static string BuildErrorMessage(Exception exception)
        {
            string message;

            if (exception is HttpRequestException responseException)
            {
                message = responseException.Message.ToString();
            }
            else
            {
                message = !string.IsNullOrEmpty(exception.Message) ? exception.Message : "ERRORS.UNKNOWN_ERROR";
            }

            return message;
        }

    }
}