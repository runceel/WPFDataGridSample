using Prism.Mvvm;
using Reactive.Bindings;

namespace WpfDataGridSampleApp.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        public ReactiveProperty<string> Title { get; }

        public ViewModelBase(string title)
        {
            this.Title = new ReactiveProperty<string>(title);
        }
    }
}