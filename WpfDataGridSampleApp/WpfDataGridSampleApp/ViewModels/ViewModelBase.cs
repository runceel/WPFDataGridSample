using System;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System.Reactive.Disposables;
using WpfDataGridSampleApp.Models;
using System.Reactive.Linq;
using Reactive.Bindings.Extensions;

namespace WpfDataGridSampleApp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        protected CompositeDisposable Disposable { get; } = new CompositeDisposable();

        protected Main Model { get; }

        public ReadOnlyReactiveProperty<string> Title { get; }

        public ReactiveProperty<Scenario> Scenario { get; } = new ReactiveProperty<Scenario>();

        public ReadOnlyReactiveCollection<Person> People { get; }

        public ViewModelBase(Main model)
        {
            this.Model = model;
            this.Title = this.Scenario
                .Where(x => x != null)
                .Select(x => x.Name)
                .ToReadOnlyReactiveProperty()
                .AddTo(this.Disposable);

            this.People = this.Model
                .People
                .ToReadOnlyReactiveCollection()
                .AddTo(this.Disposable);
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.Scenario.Value = (Scenario)navigationContext.Parameters["scenario"];
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.Disposable.Dispose();
        }
    }
}