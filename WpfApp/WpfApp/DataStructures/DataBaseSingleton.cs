using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.DataStructures
{
    public class DataBaseSingleton
    {
        private static DataBaseSingleton instance;

        private List<Sms> smsList = new List<Sms>();
        private int nextFreeSmsId = 1; 
        private List<Email> emailList = new List<Email>();
        private int nextFreeEmailId = 1;
        private List<Tweet> tweetList = new List<Tweet>();
        private int nextFreeTweetId = 1;

        private DataBaseSingleton() { }


        // Getter and Setters
        public List<Sms> SmsList
        {
            get { return smsList; }
            set { smsList = value; }
        }

        public int NextFreeSmsId
        {
            get { return nextFreeSmsId; }
            set { nextFreeSmsId = value; }
        }

        public List<Email> EmailList
        {
            get { return emailList; }
            set { emailList = value; }
        }

        public int NextFreeEmailId
        {
            get { return nextFreeEmailId; }
            set { nextFreeEmailId = value; }
        }

        public List<Tweet> TweetList
        {
            get { return tweetList; }
            set { tweetList = value; }
        }

        public int NextFreeTweetId
        {
            get { return nextFreeTweetId; }
            set { nextFreeTweetId = value; }
        }

        public static DataBaseSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataBaseSingleton();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

    }
}
