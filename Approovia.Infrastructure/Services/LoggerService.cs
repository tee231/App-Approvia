using Approovia.Core.Exceptions;
using Approovia.Core.Interface.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approovia.Infrastructure.Services
{
   public class LoggerService<T> : ILoggerService<T>
    {
        private readonly ILogger _logger;
        public LoggerService(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogDebug(Exception ex)
        {
            _ = Task.Run(() =>
            {
                _logger.LogDebug(ex, ex.Message, ErrorDetails(ex));
            });
        }

        public void LogError(Exception ex)
        {
            _ = Task.Run(() =>
            {
                string[] errorDetails = ErrorDetails(ex);
                _logger.LogError(ex, string.Join("|", errorDetails), errorDetails);
            });
        }

        public void LogInformation(string msg)
        {
            _ = Task.Run(() =>
            {
                _logger.LogInformation(msg);
            });
        }

        public void LogWarning(Exception ex)
        {
            _ = Task.Run(() =>
            {
                string[] errorDetails = ErrorDetails(ex);
                _logger.LogWarning(ex, string.Join("|", errorDetails), errorDetails);
            });
        }

        private string[] ErrorDetails(Exception ex)
        {
            if (ex is BaseException)
            {
                var x = (BaseException)ex;
                return new string[] {
                $"Message => {x.Message}",
                $"Stacktrace => {x.StackTrace}",
                $"InnerException => {x.InnerException}",
                $"HttpStatus => {x.httpStatusCode}"
                };
            }
            else
            {
                return new string[] {
                $"Message => {ex.Message}",
                $"Stacktrace => {ex.StackTrace}",
                $"InnerException => {ex.InnerException}"
                };
            }
        }
    }


}
