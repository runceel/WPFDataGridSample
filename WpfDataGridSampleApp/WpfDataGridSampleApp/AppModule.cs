using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDataGridSampleApp.Models;
using WpfDataGridSampleApp.Views;

namespace WpfDataGridSampleApp
{
    public class AppModule : IModule
    {
        private IRegionManager RegionManager { get; }

        private IUnityContainer Container { get; }

        public AppModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.Container = container;
        }

        public void Initialize()
        {
            // Register views
            this.Container.RegisterTypes(
                AllClasses.FromLoadedAssemblies()
                    .Where(x => x.FullName.StartsWith("WpfDataGridSampleApp.Views."))
                    .Where(x => x.Name.EndsWith("View")),
                _ => new[] { typeof(object) },
                WithName.TypeName,
                WithLifetime.PerResolve);

            this.Container.RegisterType<Main>(new ContainerControlledLifetimeManager());

            this.RegionManager.RequestNavigate("MainRegion", nameof(ScenarioSelectView));
        }
    }
}
