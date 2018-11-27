using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.Model;

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for ProcessedMessage.xaml
    /// </summary>
    public partial class ProcessedMessage : Window
    {
        private Message message;

        public ProcessedMessage(Message message)
        {
            InitializeComponent();
            this.message = message;
            UpdateComponents();
        }

        private void UpdateComponents()
        {
            IdText.Content = message.Id;
            SenderText.Content = message.Sender;
            MessageTextBox.Text = message.MessageBody;
            if (message.Id[0].Equals('e'))
            {
                if (!((Email)message).Sir)
                {
                    SubjectLabel.Visibility = Visibility.Visible;
                    SubjectText.Visibility = Visibility.Visible;

                    SubjectText.Content = ((Email)message).Subject;
                }
            }
        }
    }
}
