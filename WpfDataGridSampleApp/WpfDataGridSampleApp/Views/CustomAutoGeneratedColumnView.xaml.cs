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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDataGridSampleApp.Models;

namespace WpfDataGridSampleApp.Views
{
    /// <summary>
    /// CustomAutoGeneratedColumnView.xaml の相互作用ロジック
    /// </summary>
    public partial class CustomAutoGeneratedColumnView : UserControl
    {
        public CustomAutoGeneratedColumnView()
        {
            InitializeComponent();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Person.Name):
                    e.Column.Header = "名前";
                    break;
                case nameof(Person.Age):
                    e.Column.Header = "年齢";
                    break;
                case nameof(Person.Gender):
                    e.Column.Header = "性別";
                    break;
                default:
                    e.Cancel = true;
                    break;
            }
        }
    }
}
