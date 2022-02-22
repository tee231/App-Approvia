using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approovia.Core.Utility
{
    public static class Constants
    {
        public static class ResponseCodes
        {
            public const string Successful = "00";
            public const string Failed = "99";
            public const string AlreadyExist = "02";
            public const string NotFound = "03";
            public const string InvalidIssuer = "04";
            public const string TokenExpired = "05";
            public const string TokenValidationFailed = "06";
            public const string InvalidAudience = "07";
            public const string Unauthorized = "08";
            public const string ModelValidation = "09";
            public const string UserNotConfirmed = "10";
            public const string PublicKeyRetrieval = "11";
            public const string SSOExceptions = "12";
            public const string Forbidden = "13";
            public const string Processing = "9009";
            public const string BankStatementError = "801";
            public const string AccountBalanceError = "802";
            public const string AccountProfilingError = "803";
            public const string AccountLookupError = "804";
            public const string TranStatusError = "805";
            public const string BankSettingError = "806";
            public const string BankPayoutError = "900";



        }

    }
}
