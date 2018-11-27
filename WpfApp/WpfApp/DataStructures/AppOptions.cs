using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.DataStructures
{
    public static class AppOptions
    {
        // General
        private static readonly List<string> messageTypes = new List<string>
        {
            "sms",
            "email",
            "tweet"
        };
        private static readonly List<string> incidentTypes = new List<string>
        {
            "Theft",
            "Staff Attack",
            "ATM Theft",
            "Raid",
            "Customer Attack",
            "Staff Abuse",
            "Bomb Threat",
            "Terrorism",
            "Suspicious Incident",
            "Intelligence",
            "Cash Loss"
        };

        // Sms 
        private static int smsMessageCharLimit = 140;

        // Email
        private static int emailMessageCharLimit = 1028;
        private static int emailSubjectCharLimit = 20;

        // Tweet
        private static int tweetMessageCharLimit = 140;
        private static int twitterIdCharLimit = 15;

        // Getters and Setters
        public static List<string> MessageTypes
        {
            get { return messageTypes; }
        }

        public static List<string> IncidentTypes
        {
            get { return incidentTypes; }
        }

        public static int SmsMessageCharLimit
        {
            get { return smsMessageCharLimit; }
            set { smsMessageCharLimit = value; }
        }

        public static int EmailMessageCharLimit
        {
            get { return emailMessageCharLimit; }
            set { emailMessageCharLimit = value; }
        }

        public static int EmailSubjectCharLimit
        {
            get { return emailSubjectCharLimit; }
            set { emailSubjectCharLimit = value; }
        }

        public static int TweetMessageCharLimit
        {
            get { return tweetMessageCharLimit; }
            set { tweetMessageCharLimit = value; }
        }

        public static int TwitterIdCharLimit
        {
            get { return twitterIdCharLimit; }
            set { twitterIdCharLimit = value; }
        }
    }
}
