using System.Collections.Generic;

namespace WpfApp.Model
{
    /* Author: Stefan Hristov
     * Student Number: 40284739
     * Last Updated: 18/11/2018
     * 
     * Class "Tweet"
     * 
     * The purpose of this class is to be used for storing messages of type Tweet.
     * 
     */
    public class Tweet : Message
    {
        private List<string> hashTags = new List<string>();
        private List<string> mentions = new List<string>();

        public Tweet() { }

        // Getters and Setters
        public List<string> HashTags
        {
            get { return hashTags; }
            set { hashTags = value; }
        }

        public List<string> Mentions
        {
            get { return mentions; }
            set { mentions = value; }
        }
    }
}
