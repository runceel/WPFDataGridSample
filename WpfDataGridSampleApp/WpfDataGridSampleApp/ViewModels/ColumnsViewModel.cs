using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDataGridSampleApp.Models;

namespace WpfDataGridSampleApp.ViewModels
{
    public class ColumnsViewModel : ViewModelBase, INavigationAware
    {
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        private Main Model { get; }

        public ReactiveProperty<Scenario> Scenario { get; }

        public ReadOnlyReactiveCollection<Person> People { get; }

        public ReadOnlyReactiveCollection<EnumLabelPair<Gender>> Genders { get; }

        public ColumnsViewModel(Main model) : base("")
        {
            this.Model = model;

            this.Scenario = new ReactiveProperty<Scenario>();
            this.Scenario
                .Where(x => x != null)
                .Subscribe(x => this.Title.Value = x.Name)
                .AddTo(Disposable);

            this.People = this.Model
                .People
                .ToReadOnlyReactiveCollection();

            this.Genders = this.Model
                .Genders
                .ToReadOnlyReactiveCollection();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.Disposable.Dispose();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.Scenario.Value = (Scenario)navigationContext.Parameters["scenario"];
        }
    }
}
