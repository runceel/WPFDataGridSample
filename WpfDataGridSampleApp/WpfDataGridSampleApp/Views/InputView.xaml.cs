using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// InputView.xaml の相互作用ロジック
    /// </summary>
    public partial class InputView : UserControl
    {
        public InputView()
        {
            InitializeComponent();
        }

        private void DataGrid_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {
            var p = e.NewItem as Person;
            var collection = CollectionViewSource.GetDefaultView(((DataGrid)sender).ItemsSource);
            var last = collection.OfType<Person>().Reverse().Skip(1).First();
            p.Name = last.Name;
            p.Age = last.Age;
        }
    }
}
