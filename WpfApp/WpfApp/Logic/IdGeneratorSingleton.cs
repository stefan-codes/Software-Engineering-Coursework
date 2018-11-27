using WpfApp.DataStructures;

namespace WpfApp.Logic
{
    /* Author: Stefan Hristov
     * Student Number: 40284739
     * Last Updated: 16/11/2018
     * 
     * Class "IdGeneratorSingleton"
     * 
     * The purpose of this class is to generate new ids for the messages.
     * It makes sure they are unique by looking into the next avaliable id
     * for each type of message.
     */
    public class IdGeneratorSingleton
    {
        private static IdGeneratorSingleton instance;

        private IdGeneratorSingleton() { }

        public string NewSmsId()
        {
            int idToUse = DataBaseSingleton.Instance.NextFreeSmsId;
            string idToReturn = "s" + idToUse.ToString().PadLeft(9, '0');
            DataBaseSingleton.Instance.NextFreeSmsId++;

            return idToReturn;
        }

        public string NewEmailId()
        {
            int idToUse = DataBaseSingleton.Instance.NextFreeEmailId;
            string idToReturn = "e" + idToUse.ToString().PadLeft(9, '0');
            DataBaseSingleton.Instance.NextFreeEmailId++;

            return idToReturn;
        }

        public string NewTweetId()
        {
            int idToUse = DataBaseSingleton.Instance.NextFreeTweetId;
            string idToReturn = "t" + idToUse.ToString().PadLeft(9, '0');
            DataBaseSingleton.Instance.NextFreeTweetId++;

            return idToReturn;
        }

        // Getter and Setter
        public static IdGeneratorSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new IdGeneratorSingleton();
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
