using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDataGridSampleApp.Models;

namespace WpfDataGridSampleApp.ViewModels
{
    public class StylingViewModel : ViewModelBase
    {
        public ReadOnlyReactiveCollection<EnumLabelPair<Gender>> Genders { get; }

        public StylingViewModel(Main model) : base(model)
        {
            this.Genders = this.Model
                .Genders
                .ToReadOnlyReactiveCollection()
                .AddTo(Disposable);
        }
    }
}
