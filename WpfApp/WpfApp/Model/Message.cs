namespace WpfApp.Model
{
    /* Author: Stefan Hristov
     * Student Number: 40284739
     * Last Updated: 18/11/2018
     * 
     * Class "Message"
     * 
     * The purpose of this class is to be a base parent for any new messages.
     * 
     */
    public abstract class Message
    {
        protected string id;
        protected string sender;
        protected string messageBody;

        public Message() { }

        // Getter and Setters
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        public string MessageBody
        {
            get { return messageBody; }
            set { messageBody = value; }
        }        
    }
}
