using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfDataGridSampleApp.Models;

namespace WpfDataGridSampleApp.ViewModels
{
    public class ScenarioSelectViewModel : BindableBase
    {
        public ReactiveProperty<string> Title { get; }

        public ReadOnlyReactiveCollection<ScenarioViewModel> Scenarios { get; }

        public ReactiveCommand<ScenarioViewModel> ScenarioSelectCommand { get; }

        public ReadOnlyReactiveProperty<bool> IsLoaded { get; }

        public ReadOnlyReactiveProperty<Visibility> IsLoadedVisibility { get; }

        public ReadOnlyReactiveProperty<int> LoadedCount { get; }

        public ScenarioSelectViewModel(Main model, IRegionManager regionManager)
        {
            this.Title = new ReactiveProperty<string>("シナリオ選択");

            this.IsLoaded = model.ObserveProperty(x => x.IsLoaded)
                .ToReadOnlyReactiveProperty();

            this.Scenarios = model.Scenarios
                .ToReadOnlyReactiveCollection(x => new ScenarioViewModel(x));

            this.IsLoadedVisibility = this.IsLoaded
                .Select(x => x ? Visibility.Collapsed : Visibility.Visible)
                .ToReadOnlyReactiveProperty();

            this.LoadedCount = model.People
                .ObserveProperty(x => x.Count)
                .Sample(TimeSpan.FromMilliseconds(50))
                .ToReadOnlyReactiveProperty();

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
