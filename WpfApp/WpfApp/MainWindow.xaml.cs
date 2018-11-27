using System;
using System.Windows;
using WpfApp.DataStructures;
using WpfApp.Logic;
using WpfApp.View;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ServiceController.LoadData();
        }

        // Open new New Message window
        private void NewMessageBtn_Click(object sender, RoutedEventArgs e)
        {
            NewMessage newMessageWindow = new NewMessage();
            newMessageWindow.Show();
        }

        // Open new Show Messages window
        private void ShowMessagesBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowMessages showMessagesWindow = new ShowMessages();
            showMessagesWindow.Show();
        }

        // Exit the application
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Read the file and try to process
        private void InputMessageBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";
            //dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Display OpenFileDialog by calling ShowDialog method 
            bool? result = dlg.ShowDialog();
            
            // Get the selected file name
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;

                if (!ServiceController.ReadMessagesFromFile(filename))
                {
                    MessageBox.Show(ServiceController.Error);
                }
            }
        }

        // Open new Trending List window
        private void TrendingListBtn_Click(object sender, RoutedEventArgs e)
        {
            TrendingList trendingListWindow = new TrendingList();
            trendingListWindow.Show();
        }

        // Open new Mentions List window
        private void MentionsListBtn_Click(object sender, RoutedEventArgs e)
        {
            MentionsList mentionsListWindow = new MentionsList();
            mentionsListWindow.Show();
        }

        // Open new Quarantine List Window
        private void QuarantineListBtn_Click(object sender, RoutedEventArgs e)
        {
            QuarantineList quarantineListWindow = new QuarantineList();
            quarantineListWindow.Show();
        }

        // Open new Sir List Window
        private void SirListBtn_Click(object sender, RoutedEventArgs e)
        {
            SirList sirListWindow = new SirList();
            sirListWindow.Show();
        }
    }
}
