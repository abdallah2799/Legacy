using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Common.Helpers
{
    public static class Validator
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static readonly Regex PhoneRegex = new Regex(
            @"^[\+]?[0-9\s\-\(\)]{10,20}$",
            RegexOptions.Compiled);

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email);
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            return PhoneRegex.IsMatch(phone);
        }

        public static bool IsValidAge(int age, int minAge = Constants.Validation.MIN_AGE, int maxAge = Constants.Validation.MAX_AGE)
        {
            return age >= minAge && age <= maxAge;
        }

        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            return password.Length >= Constants.Validation.MIN_PASSWORD_LENGTH &&
                   password.Length <= Constants.Validation.MAX_PASSWORD_LENGTH;
        }

        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            // Username should be 3-50 characters, alphanumeric and underscores only
            var usernameRegex = new Regex(@"^[a-zA-Z0-9_]{3,50}$");
            return usernameRegex.IsMatch(username);
        }

        public static bool IsValidDateRange(DateTime startDate, DateTime endDate)
        {
            return startDate <= endDate;
        }

        public static bool IsValidExamDuration(int durationMinutes)
        {
            return durationMinutes >= Constants.Defaults.MIN_EXAM_DURATION_MINUTES &&
                   durationMinutes <= Constants.Defaults.MAX_EXAM_DURATION_MINUTES;
        }

        public static bool IsValidQuestionMarks(int marks)
        {
            return marks >= Constants.Defaults.MIN_QUESTION_MARKS &&
                   marks <= Constants.Defaults.MAX_QUESTION_MARKS;
        }

        public static bool IsValidPassPercentage(int passPercentage)
        {
            return passPercentage >= 0 && passPercentage <= 100;
        }
    }
}
