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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDataGridSampleApp.Models;

namespace XamDataGridSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var r = new Random();
            this.DataContext = Enumerable.Range(1, 1000000)
                .Select(x => new Person
                {
                    Name = $"サンプル　太郎{x}",
                    Age = r.Next(100).ToString(),
                    Birthday = DateTime.Now,
                    Gender = Gender.Men,
                })
                .ToArray();
        }
    }
}
