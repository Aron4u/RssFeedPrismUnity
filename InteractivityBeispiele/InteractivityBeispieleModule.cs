using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteractivityBeispiele.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using RssInfrastructure;

namespace InteractivityBeispiele
{
  public class InteractivityBeispieleModule:IModule
  {
        private IUnityContainer container;
    private IRegionManager regionManager;

    public InteractivityBeispieleModule(IUnityContainer container, IRegionManager regionManager)
    {
      this.container = container;
      this.regionManager = regionManager;

    

    }


    public void Initialize()
    {
      regionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(NavigateInteractivityBeispieleView));

    }
  }
}
