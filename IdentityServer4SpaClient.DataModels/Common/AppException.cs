using System;

namespace IdentityServer4SpaClient.DataModels.Common
{
    /// <inheritdoc />
    /// <summary>
    /// Custom Exception class with custom exception types
    /// </summary>
    public class AppException : Exception
    {
        public AppExceptionType? ExceptionType { get; set; }
        public Exception OriginalException { get; set; }
        public string VerboseLog { get; set; }

        public AppException(string message) : base(message)
        {
        }

        public AppException(string message, AppExceptionType statusCode, Exception originalException = null, string verboseLog = null) : base(message)
        {
            ExceptionType = statusCode;
            OriginalException = originalException;
            VerboseLog = verboseLog;
        }
    }

    public enum AppExceptionType
    {
        Client,
        Authorization,
        Authentication,
        Server,
        Wtf
    }
}