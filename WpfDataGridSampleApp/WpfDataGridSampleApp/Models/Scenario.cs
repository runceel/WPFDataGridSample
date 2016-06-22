using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataGridSampleApp.Models
{
    public class Scenario : BindableBase
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value); }
        }

        private string viewName;

        public string ViewName
        {
            get { return this.viewName; }
            set { this.SetProperty(ref this.viewName, value); }
        }

    }
}
