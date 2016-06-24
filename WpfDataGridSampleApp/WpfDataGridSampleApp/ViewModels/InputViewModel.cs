using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;
using WpfDataGridSampleApp.Models;
using System.Collections.ObjectModel;

namespace WpfDataGridSampleApp.ViewModels
{
    public class InputViewModel : ViewModelBase
    {
        private ObservableCollection<Person> editablePeople;

        public ObservableCollection<Person> EditablePeople
        {
            get { return this.editablePeople; }
            set { this.SetProperty(ref this.editablePeople, value); }
        }


        public InputViewModel(Main model) : base(model)
        {
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            this.EditablePeople = new ObservableCollection<Person>(this.People.Take(10));
        }
    }
}
