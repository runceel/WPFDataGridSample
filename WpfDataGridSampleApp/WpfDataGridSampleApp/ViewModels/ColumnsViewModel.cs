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
    public class ColumnsViewModel : ViewModelBase
    {
        public ReadOnlyReactiveCollection<EnumLabelPair<Gender>> Genders { get; }

        public ColumnsViewModel(Main model) : base(model)
        {
            this.Genders = this.Model
                .Genders
                .ToReadOnlyReactiveCollection();
        }
    }
}
