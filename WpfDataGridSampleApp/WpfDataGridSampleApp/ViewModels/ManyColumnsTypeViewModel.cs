﻿using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDataGridSampleApp.Models;

namespace WpfDataGridSampleApp.ViewModels
{
    public class ManyColumnsTypeViewModel : ViewModelBase
    {
        public ReadOnlyReactiveCollection<EnumLabelPair<Gender>> Genders { get; }

        public ManyColumnsTypeViewModel(Main model) : base(model)
        {
            this.Genders = this.Model
             .Genders
             .ToReadOnlyReactiveCollection()
             .AddTo(this.Disposable);
        }
    }
}
