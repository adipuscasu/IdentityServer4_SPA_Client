using IdentityServer4SpaClient.DataModels.Common;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

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
        public static HttpResponseException CreateFriendlyException(Exception exception)
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
        public static HttpResponseException CreateDetailedException(Exception exception)
        {
            var errorMessage = BuildErrorMessage(exception);

            return CreateException(HttpStatusCode.InternalServerError, errorMessage);
        }

        /// <summary>
        /// Create a custom http exception.
        /// </summary>
        /// <param name="appException">Caught exception to be forwarded</param>
        /// <returns></returns>
        public static HttpResponseException CreateException(AppException appException)
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
        private static HttpResponseException CreateException(HttpStatusCode httpStatusCode, string message)
        {
            return new HttpResponseException(new HttpResponseMessage(httpStatusCode)
            {
                Content = new ObjectContent<HttpError>(new HttpError(message), new JsonMediaTypeFormatter())
            });
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

            if (exception is HttpResponseException responseException)
            {
                message = responseException.Response.ReasonPhrase;
            }
            else
            {
                message = !string.IsNullOrEmpty(exception.Message) ? exception.Message : "ERRORS.UNKNOWN_ERROR";
            }

            return message;
        }

    }
}