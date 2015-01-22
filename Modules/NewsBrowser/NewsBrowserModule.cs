using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using NewsBrowser.Views;
using RssInfrastructure;

namespace NewsBrowser
{
  public class NewsBrowserModule:IModule
  {
        private IUnityContainer container;
    private IRegionManager regionManager;

    public NewsBrowserModule(IUnityContainer container, IRegionManager regionManager)
    {
      this.container = container;
      this.regionManager = regionManager;

    

    }


    public void Initialize()
    {
      regionManager.RegisterViewWithRegion(RegionNames.DetailsRegion, typeof(BrowserView));
      regionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(NavigateBrowserView));

    }
  }
}
