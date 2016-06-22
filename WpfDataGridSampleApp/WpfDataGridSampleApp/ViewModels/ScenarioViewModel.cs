using WpfDataGridSampleApp.Models;

namespace WpfDataGridSampleApp.ViewModels
{
    public class ScenarioViewModel
    {
        public Scenario Model { get; }

        public string Name => this.Model.Name;

        public ScenarioViewModel(Scenario model)
        {
            this.Model = model;
        }
    }
}