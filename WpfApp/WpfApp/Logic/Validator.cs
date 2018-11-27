using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;
using WpfApp.DataStructures;

namespace WpfApp.Logic
{
    public static class Validator
    {
        private static string error = "";

        // Is the Sms valid?
        public static bool IsSmsValid(Sms sms)
        {
            if (!IsValidPhoneNumber(sms.Sender))
            {
                return false;
            }

            if (!IsValidMessage("Sms", sms.MessageBody, AppOptions.SmsMessageCharLimit))
            {
                return false;
            }

            return true;
        }

        // Is the Email valid?
        public static bool IsEmailValid(Email email)
        {
            if (!IsValidEmailAddress(email.Sender))
            {
                return false;
            }

            if (!IsValidEmailSubject(email.Subject))
            {
                return false;
            }

            if (!IsValidEmailSortCode(email.SortCode))
            {
                return false;
            }

            if (!IsValidMessage("Email", email.MessageBody, AppOptions.EmailMessageCharLimit))
            {
                return false;
            }

            return true;
        }

        // Is the Tweet valid?
        public static bool IsTweetValid(Tweet tweet)
        {
            if (!IsValidTweeterId(tweet.Sender))
            {
                return false;
            }

            if (!IsValidMessage("Tweeter", tweet.MessageBody, AppOptions.TweetMessageCharLimit))
            {
                return false;
            }

            return true;
        }

        // Is the string a valid international phone number
        private static bool IsValidPhoneNumber(string number)
        {
            string allowedChars = "+0123456789 -";
            int phoneNumberMaxChar = 15;
            int phoneNumberMinChar = 5;

            // If the number is too short
            if (number.Length < phoneNumberMinChar)
            {
                error = $"The phone number must be minimum {phoneNumberMinChar} characters. ";
                return false;
            }

            // If the number is too long
            if (number.Length > phoneNumberMaxChar)
            {
                error = $"The phone number must be maximum {phoneNumberMaxChar} characters. ";
                return false;
            }

            // If the number contains illegal chars
            foreach (char c in number)
            {
                if (!allowedChars.Contains(c))
                {
                    error = "The phone number contains illegal characters.";
                    return false;
                }
            }

            // If the number doesnt start with '+'
            if (!number[0].Equals('+'))
            {
                error = "The phone number must start with '+'.";
                return false;
            }

            return true;
        }

        // Is the string a valid email address
        private static bool IsValidEmailAddress(string email)
        {
            // No shorter than 5 chars
            if (email.Length < 5)
            {
                error = "Email address is too short.";
                return false;
            }

            int lastChar = email.Length - 1;

            if (email[0].Equals('@') || email[0].Equals('.'))
            {
                error = "Email can not start with '@' or '.' .";
                return false;
            }

            if (email[lastChar].Equals('@') || email[lastChar].Equals('.'))
            {
                error = "Email address can not finish with '@' or '.' .";
                return false;
            }             

            string[] parts = email.Split('@');

            if (!parts.Length.Equals(2))
            {
                error = "Email address must have only one @ sign.";
                return false;
            }

            string[] parts2 = parts[1].Split('.');

            if (!(parts2.Length >= 2))
            {
                error = "Email address must have at least one '.' after the @ sign.";
                return false;
            }
            
            return true;
        }

        // Is the string a valid email subject?
        private static bool IsValidEmailSubject(string subject)
        {
            if (subject.Length > AppOptions.EmailSubjectCharLimit)
            {
                error = $"Email subject is too long. Maximum {AppOptions.EmailSubjectCharLimit} characters allowed.";
                return false;
            }

            return true;
        }

        // Is the string a valid email sort code?
        private static bool IsValidEmailSortCode(string sortCode)
        {
            string numbers = "0123456789";
            char allowedSymbols = '-';

            if (sortCode.Equals(""))
            {
                return true;
            }

            if (sortCode.Length == 8)
            {
                char[] chars = sortCode.ToCharArray();

                // are 3 and 6 a dash?
                if (!(chars[2].Equals(allowedSymbols) && chars[5].Equals(allowedSymbols)))
                {
                    error = "Sort Code is invalid";
                    return false;
                }

                char[] numbsOnly =
                {
                    chars[0],
                    chars[1],
                    chars[3],
                    chars[4],
                    chars[6],
                    chars[7]
                };

                foreach(char c in numbsOnly)
                {
                    if (!numbers.Contains(c))
                    {
                        error = "Sort Code is invalid";
                        return false;
                    }
                }

                return true;
            }

            error = "Sort Code is invalid";
            return false;
        }

        // Is the string a valid tweeter Id
        private static bool IsValidTweeterId(string tweeterId)
        {
            int minimumCharacters = 5;

            if (tweeterId.Length < minimumCharacters)
            {
                error = $"Tweeter ID can not be shorter than {minimumCharacters} characters.";
                return false;
            }

            if (!tweeterId[0].Equals('@'))
            {
                error = $"Tweeter ID must start with @ character.";
                return false;
            }

            if (tweeterId.Length > AppOptions.TwitterIdCharLimit)
            {
                error = $"Tweeter ID can not be longer than {AppOptions.TwitterIdCharLimit} characters.";
                return false;
            }

            return true;
        }

        // Is the string between 1 and max characters
        private static bool IsValidMessage(string name, string text, int maxChar)
        {
            if (text.Length < 1)
            {
                error = $"{name} message can not be empty.";
                return false;
            }

            if (text.Length > maxChar)
            {
                error = $"{name} message is too long. Maximum {maxChar} characters allowed.";
                return false;
            }

            return true;
        }

        // Getters and Setters
        public static string Error
        {
            get { return error; }
        }
    }
}
