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
using WpfApp.DataStructures;
using WpfApp.Model;

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for ShowMessages.xaml
    /// </summary>
    public partial class ShowMessages : Window
    {
        public ShowMessages()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataGrid.Items.Clear();
            List<Message> messages = new List<Message>();
            messages.AddRange(DataBaseSingleton.Instance.SmsList);
            messages.AddRange(DataBaseSingleton.Instance.EmailList);
            messages.AddRange(DataBaseSingleton.Instance.TweetList);
            DataGrid.ItemsSource = messages;
        }
    }
}
