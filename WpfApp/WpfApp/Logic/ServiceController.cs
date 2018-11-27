using System;
using System.Collections.Generic;
using System.Linq;
using WpfApp.DataStructures;
using WpfApp.Model;
using WpfApp.View;

namespace WpfApp.Logic
{
    /* Author: Stefan Hristov
     * Student Number: 40284739
     * Last Updated: 18/11/2018
     * 
     * Class "ServiceController"
     * 
     * //TODO: purpose of this class
     * The purpose of this class is to ...
     * 
     */
    public static class ServiceController
    {
        private static string error = "Something went wrong! MessageService.cs";

        // Decides what message we have
        public static bool NewMessage(int messageType, string sender, string message, bool sir = false, int natureOfIncidentIndex = -1, string sortcode = "", string subject = "")
        {
            switch (messageType)
            {
                // Sms
                case 0:
                    // Create a sms
                    Sms sms = new Sms
                    {
                        Sender = sender,
                        MessageBody = message
                    };

                    // Try to process it
                    if (!NewSms(sms))
                    {
                        return false;
                    }

                    return true;
                //Email
                case 1:
                    Email email = new Email
                    {
                        Sender = sender,
                        MessageBody = message,
                        Subject = subject,
                        Sir = sir,
                        NatureOfIncident = "",
                        SortCode = sortcode
                    };

                    if (email.Sir)
                    {
                        email.NatureOfIncident = AppOptions.IncidentTypes.ElementAt(natureOfIncidentIndex);
                        email.Subject = DateTime.Now.ToString("SIR dd/MM/yyyy");
                    }

                    // Try to process it
                    if (!NewEmail(email))
                    {
                        return false;
                    }

                    return true;
                //Tweet
                case 2:
                    Tweet tweet = new Tweet
                    {
                        Sender = sender,
                        MessageBody = message
                    };

                    if (!NewTweet(tweet))
                    {
                        return false;
                    }
                    
                    return true;
                default:
                    error = "Unidentified message type. Please select a message type!";
                    return false;
            }
        }

        // Controller for message of type SMS
        private static bool NewSms(Sms sms)
        {
            // Check for validity
            if (!Validator.IsSmsValid(sms))
            {
                error = Validator.Error;
                return false;
            }

            // Generate ID
            sms.Id = IdGeneratorSingleton.Instance.NewSmsId();

            // Sanitize
            Sanitizer.SanitizeSms(sms);

            // Add to the list in memory
            DataBaseSingleton.Instance.SmsList.Add(sms);

            // Serialize
            Persistence.Serialize();

            // Display it
            ProcessedMessage processedMessageWindow = new ProcessedMessage(sms);
            processedMessageWindow.Show();

            return true;
        }

        // Email Controller
        private static bool NewEmail(Email email)
        {
            // Check for validity
            if (!Validator.IsEmailValid(email))
            {
                error = Validator.Error;
                return false;
            }

            // Generate ID
            email.Id = IdGeneratorSingleton.Instance.NewEmailId();

            // Sanitize
            Sanitizer.SanitizeEmail(email);

            // Add to the list in memory
            DataBaseSingleton.Instance.EmailList.Add(email);

            // Serialize
            Persistence.Serialize();

            // Display it
            ProcessedMessage processedMessageWindow = new ProcessedMessage(email);
            processedMessageWindow.Show();

            return true;
        }

        // Tweet Controller
        private static bool NewTweet(Tweet tweet)
        {
            // Check for validity
            if (!Validator.IsTweetValid(tweet))
            {
                error = Validator.Error;
                return false;
            }

            // Generate ID
            tweet.Id = IdGeneratorSingleton.Instance.NewTweetId();

            // Sanitize
            Sanitizer.SanitizeTweet(tweet);

            // Add to the list in memory
            DataBaseSingleton.Instance.TweetList.Add(tweet);

            // Serialize
            Persistence.Serialize();

            // Display it
            ProcessedMessage processedMessageWindow = new ProcessedMessage(tweet);
            processedMessageWindow.Show();

            return true;
        }

        // Produces a trending dictionary based on the existing tweets
        public static Dictionary<string, int> ProduceTrendingDictionary()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            // For every tweet
            foreach(Tweet t in DataBaseSingleton.Instance.TweetList)
            {
                // If it has hash tags
                if (t.HashTags.Count() > 0)
                {
                    // For every hash tag
                    for (int i = 0; i < t.HashTags.Count(); i++)
                    {
                        // If the hash tag is in the dictionary
                        if (result.ContainsKey(t.HashTags.ElementAt(i)))
                        {
                            result[t.HashTags.ElementAt(i)]++;
                        } else
                        {
                            result.Add(t.HashTags.ElementAt(i), 1);
                        }
                    }
                }
            }

            return result;
        }

        // Produces a mentions dictionary based on the existing tweets
        public static Dictionary<string, string> ProduceMentionsDictionary()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            // For every tweet
            foreach (Tweet t in DataBaseSingleton.Instance.TweetList)
            {
                // If it has mentions
                if (t.Mentions.Count() > 0)
                {
                    string mentions = string.Join(", ", t.Mentions);
                    result.Add(t.Id, mentions);
                }
            }
            return result;
        }

        // Produce a quarantine dictionary based on the existing emails
        public static Dictionary<string, string> ProduceQuarantineDictionary()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            // For every email
            foreach (Email e in DataBaseSingleton.Instance.EmailList)
            {
                // If it has urls
                if (e.QuarantineList.Count() > 0)
                {
                    // For every url 
                    foreach (string url in e.QuarantineList)
                    {
                        // If the url is in the dictionary
                        if (result.ContainsKey(url))
                        {
                            result[url] += ", " + e.Id;
                        }
                        else
                        {
                            result.Add(url, e.Id);
                        }
                    }
                }
            }

            return result;
        }
        
        // Produce a SIR dictionary based on the existing emails
        public static Dictionary<string, string> ProduceSirDictionary()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            // For every email
            foreach (Email e in DataBaseSingleton.Instance.EmailList)
            {
                // If it is sir
                if (e.Sir)
                {
                    string str = e.SortCode + ", " + e.NatureOfIncident;
                    result.Add(e.Id, str);
                }
            }

            return result;
        }

        // Load from a file
        public static bool ReadMessagesFromFile(string filePath)
        {
            Console.WriteLine("Service Controller entered.");
            if (!ReadFromFile.Read(filePath))
            {
                error = ReadFromFile.Error;
                return false;
            }
            return true;
        }

        // Load the Dictionary and Message Records
        public static void LoadData()
        {
            // Load the text-abbreviation dictionary
            TextSpeakAbbreviations.LoadFile();

            // Deserialize all
            Persistence.DeSerialize();
        }

        // Getter
        public static string Error
        {
            get { return error; }
        }

    }
}
