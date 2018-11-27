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
using WpfApp.Logic;

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for SirList.xaml
    /// </summary>
    public partial class SirList : Window
    {
        public SirList()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataGrid.Items.Clear();
            DataGrid.ItemsSource = ServiceController.ProduceSirDictionary();
        }
    }
}
