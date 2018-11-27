﻿using System;
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
using WpfApp.Logic;

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for MentionsList.xaml
    /// </summary>
    public partial class MentionsList : Window
    {
        public MentionsList()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataGrid.Items.Clear();
            DataGrid.ItemsSource = ServiceController.ProduceMentionsDictionary();
        }
    }
}
