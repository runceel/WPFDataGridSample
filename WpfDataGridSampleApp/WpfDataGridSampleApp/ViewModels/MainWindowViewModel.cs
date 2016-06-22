using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfDataGridSampleApp.Views;

namespace WpfDataGridSampleApp.ViewModels
{
    public class MainWindowViewModel
    {
        public ReactiveCommand CloseTabCommand { get; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.CloseTabCommand = new ReactiveCommand();
            this.CloseTabCommand.Subscribe(x =>
            {
                if (x is ScenarioSelectView) { return; }
                regionManager.Regions["MainRegion"].Remove(x);
            });
        }
    }
}
