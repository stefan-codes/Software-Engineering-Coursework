using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfApp.DataStructures;
using WpfApp.Model;

namespace WpfApp.Logic
{
    public static class Sanitizer
    {
        // HashSets so I guarantee there are no duplicates
        private static HashSet<string> quarantineUrls = new HashSet<string>();
        private static HashSet<string> atMentions = new HashSet<string>();
        private static HashSet<string> hashTags = new HashSet<string>();

        // Sms Sanitizer
        public static void SanitizeSms(Sms sms)
        {
            try
            {
                sms.MessageBody = ExpandAbbreviations(sms.MessageBody);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception in SanitizeSms"+e.ToString());
            }
        }

        // Email Sanitizer
        public static void SanitizeEmail(Email email)
        {
            try
            {
                email.MessageBody = RemoveUrls(email.MessageBody);
                email.QuarantineList = quarantineUrls.ToList();

                // If SIR add the SortCode and Incident type to the body
                if (email.Sir)
                {
                    email.MessageBody = email.SortCode + Environment.NewLine + email.NatureOfIncident + Environment.NewLine + email.MessageBody;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception in SanitizeEmail" + e.ToString());
            }
        }

        // Tweet Sanitizer
        public static void SanitizeTweet(Tweet tweet)
        {
            try
            {
                // Expand abbreviations
                tweet.MessageBody = ExpandAbbreviations(tweet.MessageBody);
                // Check for hashtags
                ReviewHashTags(tweet.MessageBody);
                tweet.HashTags = hashTags.ToList();
                // Check for mentions
                ReviewAtMention(tweet.MessageBody);
                tweet.Mentions = atMentions.ToList();
                
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception in SanitizeTweet" + e.ToString());
            }
        }

        // Expands all the abbreviations in the string and return it.
        private static string ExpandAbbreviations(string message)
        {
            string[] words = message.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                string upWord = words[i].ToUpper();
                for (int j = 0; j < TextSpeakAbbreviations.AbbreviationsDictionary.Count; j++)
                {
                    // If a word from the dictionary is present, write after it
                    if (TextSpeakAbbreviations.AbbreviationsDictionary.ElementAt(j).GetValue(0).Equals(upWord))
                    {
                        string stringToInsert = " <" + TextSpeakAbbreviations.AbbreviationsDictionary.ElementAt(j).GetValue(1) + ">";
                        words[i] = words[i] + stringToInsert;
                    }
                }
            }

            message = string.Join(" ", words);
            
            return message;
        }

        // Removes any urls and replaces them with a tag. Urls are added to the quarantineUrls list
        private static string RemoveUrls(string message)
        {
            string[] urlIndicators = { "www.", ".com", ".net", ".uk", "http", "https" };
            string subtituteString = "<URL Quarantined>";

            quarantineUrls.Clear();

            string[] words = message.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                string downWord = words[i].ToLower();
                foreach(string indicator in urlIndicators)
                {
                    if (downWord.Contains(indicator))
                    {
                        quarantineUrls.Add(words[i]);
                        words[i] = subtituteString;
                        break;
                    }
                }
            }

            message = string.Join(" ", words);
            
            return message;
        }

        // Check for @mentions and adds the unique ones to a list for the message
        private static void ReviewAtMention(string message)
        {
            atMentions.Clear();

            string[] words = message.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i][0].Equals('@'))
                {
                    atMentions.Add(words[i]);
                }
            }
        }

        // Check for #tags and adds the unique ones to a list for the message
        private static void ReviewHashTags(string message)
        {
            hashTags.Clear();

            string[] words = message.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i][0].Equals('#'))
                {
                    hashTags.Add(words[i]);
                }
            }
        }
    }
}
