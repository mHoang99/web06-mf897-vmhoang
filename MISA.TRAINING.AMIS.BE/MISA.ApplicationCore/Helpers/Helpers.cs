using MISA.ApplicationCore.Entities;
using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace MISA.ApplicationCore.Helpers
{
    /// <summary>
    /// Class chứa các hàm dùng chung
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Chuyển từ ServiceResult sang ApiErrorReturn
        /// </summary>
        /// <param name="serviceResult"></param>
        /// <returns>instance của ApiErrorReturn</returns>
        public static ApiErrorReturn ConvertToApiReturn(this ServiceResult serviceResult)
        {
            var aer = new ApiErrorReturn
            {
                DevMsg = serviceResult.DevMsg,
                UserMsg = serviceResult.UserMsg,
                ErrorCode = $"misa-{serviceResult.MISACode.GetHashCode()}"
            };

            return aer;
        }
    }

    public static class Validator
    {
        public static bool IsValidEmail(string email)
        {
            if (!MailAddress.TryCreate(email, out var mailAddress))
                return false;

            // And if you want to be more strict:
            var hostParts = mailAddress.Host.Split('.');
            if (hostParts.Length == 1)
                return false; // No dot.
            if (hostParts.Any(p => p == string.Empty))
                return false; // Double dot.
            if (hostParts[^1].Length < 2)
                return false; // TLD only one letter.

            if (mailAddress.User.Contains(' '))
                return false;
            if (mailAddress.User.Split('.').Any(p => p == string.Empty))
                return false; // Double dot or dot at end of user part.

            return true;
        }

        public static bool IsValidPhoneNumber(string number)
        {
            return true;
            //PhoneNumber queryPhoneNumber = phoneUtil.Parse(number, null);

            //if (phoneUtil.IsValidNumber(queryPhoneNumber))

            //{

            //    resultPhoneNumber = queryPhoneNumber.NationalNumber.ToString();

            //}
            //return Regex.Match(number, @"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$").Success;
        }
    }
}
