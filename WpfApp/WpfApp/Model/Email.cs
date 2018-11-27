using System.Collections.Generic;

namespace WpfApp.Model
{
    /* Author: Stefan Hristov
     * Student Number: 40284739
     * Last Updated: 18/11/2018
     *
     * Class "Email"
     *
     * The purpose of this class is to be used for storing messages of type Email.
     * 
     */
    public class Email : Message
    {
        private string subject;
        // Significant Incident Report (sir)
        private bool sir;
        private string natureOfIncident;
        private string sortCode;
        private List<string> quarantineList = new List<string>();
        

        public Email() { }

        // Getter and Setters
        public bool Sir
        {
            get { return this.sir; }
            set { this.sir = value; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string NatureOfIncident
        {
            get { return natureOfIncident; }
            set { natureOfIncident = value; }
        }

        public string SortCode
        {
            get { return sortCode; }
            set { sortCode = value; }
        }

        public List<string> QuarantineList
        {
            get { return quarantineList; }
            set { quarantineList = value; }
        }
    }
}
