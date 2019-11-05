using System;
using IdentityServer4SpaClient.DataModels.Common;
using IdentityServer4SpaClient.DataModels.Helpers;

namespace IdentityServer4SpaClient.REST_API.Logs
{
    /// <summary>
    /// Factory class that provides a way to build standard errors.
    /// Always throw errors that will be returned to the client using this factory class.
    /// </summary>
    public static class AppExceptionFactory
    {
        /// <summary>
        /// Creates an app error for which the client must take responsibility.
        /// Indicates an error caused by client request arguments or client status.
        /// In most cases, is used to forward handled exceptions.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <returns>Client exception</returns>
        public static AppException CreateClientException(string message)
        {
            return CreateException(AppExceptionType.Client, message);
        }

        /// <summary>
        /// Creates an app error when the client is denied access to a specific resource or function.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <returns>Authentication exception</returns>
        public static AppException CreateAuthorizationException(string message)
        {
            return CreateException(AppExceptionType.Authorization, message);
        }

        /// <summary>
        /// Creates an app error when the client requesting access to a specific resource
        /// with an invalid or expired token
        /// </summary>
        /// <param name="message">Error message</param>
        /// <returns>Authentication exception</returns>
        public static AppException CreateAuthenticationException(string message)
        {
            return CreateException(AppExceptionType.Authentication, message);
        }

        /// <summary>
        /// Creates an app error for which the server takes responsibility.
        /// Indicates an unexpected error or an API malfunction.
        /// In most cases, handles failures caused by external providers.
        /// (e.g. db connection failure, email service failure)
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="originalException"></param>
        /// <param name="verboseLog"></param>
        /// <returns>Server exception</returns>
        public static AppException CreateServerException(string message, Exception originalException = null, string verboseLog = null)
        {
            return CreateException(AppExceptionType.Server, message, originalException, verboseLog);
        }

        /// <summary>
        /// Overload for CreateServerException that allows
        /// passing a list of arguments along with a message key
        /// </summary>
        /// <param name="messageResult"></param>
        /// <param name="originalException"></param>
        /// <param name="verboseLog"></param>
        /// <returns></returns>
        public static AppException CreateServerException(MessageResult messageResult, Exception originalException = null, string verboseLog = null)
        {
            return CreateServerException(messageResult.ToJson());
        }

        /// <summary>
        /// "What a Terrible Failure"
        /// Report an exception that should never happen
        /// </summary>
        /// <param name="message">The exception message should make the developer question all his life decisions</param>
        /// <returns>Misery</returns>
        public static AppException CreateWtfException(string message)
        {
            return CreateException(AppExceptionType.Wtf, message);
        }

        /// <summary>
        /// Create a custom app exception.
        /// </summary>
        /// <param name="exceptionType">App exception type</param>
        /// <param name="message">Error message</param>
        /// <param name="originalException"></param>
        /// <returns>Custom app exception</returns>
        private static AppException CreateException(AppExceptionType exceptionType, string message, Exception originalException = null, string verboseLog = null)
        {
            return new AppException(message, exceptionType, originalException, verboseLog);
        }
    }
}
