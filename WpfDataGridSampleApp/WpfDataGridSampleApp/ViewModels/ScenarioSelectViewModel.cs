using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDataGridSampleApp.Models;

namespace WpfDataGridSampleApp.ViewModels
{
    public class ScenarioSelectViewModel : ViewModelBase
    {
        public ReadOnlyReactiveCollection<ScenarioViewModel> Scenarios { get; }

        public ReactiveCommand<ScenarioViewModel> ScenarioSelectCommand { get; }

        public ScenarioSelectViewModel(Main model, IRegionManager regionManager) : base("シナリオ選択")
        {
            this.Scenarios = model.Scenarios
                .ToReadOnlyReactiveCollection(x => new ScenarioViewModel(x));

            this.ScenarioSelectCommand = new ReactiveCommand<ScenarioViewModel>();
            this.ScenarioSelectCommand.Subscribe(x =>
            {
                var p = new NavigationParameters();
                p.Add("scenario", x.Model);
                regionManager.RequestNavigate("MainRegion", x.Model.ViewName, p);
            });
        }
    }
}
