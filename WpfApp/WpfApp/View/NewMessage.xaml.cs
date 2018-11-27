using System.Windows;
using System.Windows.Controls;
using WpfApp.DataStructures;
using WpfApp.Logic;

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for NewMessage.xaml
    /// </summary>
    public partial class NewMessage : Window
    {
        public NewMessage()
        {
            InitializeComponent();
            MessageTypeComboBox.ItemsSource = AppOptions.MessageTypes;
        }

        private void SirCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            NatureComboBox.ItemsSource = null;
            NatureComboBox.ItemsSource = AppOptions.IncidentTypes;
            SubjectLabel.Visibility = Visibility.Collapsed;
            SubjectTextBox.Visibility = Visibility.Collapsed;

            NatureLabel.Visibility = Visibility.Visible;
            NatureComboBox.Visibility = Visibility.Visible;

            SortCodeLabel.Visibility = Visibility.Visible;
            SortCodeTextBox.Visibility = Visibility.Visible;
        }

        private void SirCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            NatureLabel.Visibility = Visibility.Collapsed;
            NatureComboBox.Visibility = Visibility.Collapsed;

            SortCodeLabel.Visibility = Visibility.Collapsed;
            SortCodeTextBox.Visibility = Visibility.Collapsed;

            SubjectLabel.Visibility = Visibility.Visible;
            SubjectTextBox.Visibility = Visibility.Visible;
        }

        private void MessageTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MessageTypeComboBox.SelectedIndex == -1)
            {
                return;
            }

            if(MessageTypeComboBox.SelectedItem.ToString() == "email")
            {
                SirCheckBox.Visibility = Visibility.Visible;
                SubjectLabel.Visibility = Visibility.Visible;
                SubjectTextBox.Visibility = Visibility.Visible;
            } else
            {
                SirCheckBox.IsChecked = false;
                SirCheckBox.Visibility = Visibility.Collapsed;
                SubjectLabel.Visibility = Visibility.Collapsed;
                SubjectTextBox.Visibility = Visibility.Collapsed;
            }

        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            //clear all fields
            MessageTypeComboBox.SelectedIndex = -1;
            SenderTextBox.Text = "";
            MessageBodyTextBox.Text = "";
            SirCheckBox.IsChecked = false;
            NatureComboBox.SelectedIndex = -1;
            SubjectTextBox.Text = "";
            SortCodeTextBox.Text = "";
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ServiceController.NewMessage(MessageTypeComboBox.SelectedIndex, SenderTextBox.Text, MessageBodyTextBox.Text, 
                (bool)SirCheckBox.IsChecked, NatureComboBox.SelectedIndex, SortCodeTextBox.Text, SubjectTextBox.Text))
            {
                Close();
            } else
            {
                // if not print why it cant
                MessageBox.Show(ServiceController.Error);
            }
            
        }
    }
}
