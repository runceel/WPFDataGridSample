using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfDataGridSampleApp.Models;

namespace WpfDataGridSampleApp.ViewModels
{
    public class SelectionModeViewModel : ViewModelBase
    {
        public IEnumerable<DataGridSelectionMode> SelectionModes => Enum.GetValues(typeof(DataGridSelectionMode)).Cast<DataGridSelectionMode>();

        public IEnumerable<DataGridSelectionUnit> SelectionUnits => Enum.GetValues(typeof(DataGridSelectionUnit)).Cast<DataGridSelectionUnit>();

        public SelectionModeViewModel(Main model) : base(model)
        {
        }
    }
}
