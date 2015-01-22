using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using RssFeed.Views;
using RssFeedBL;
using RssInfrastructure;

namespace RssFeed
{
  [Module(ModuleName = "RssFeedModule", OnDemand=false)]
  public class RssFeedModule:IModule
  {
    private IUnityContainer container;
    private IRegionManager regionManager;

    public RssFeedModule(IUnityContainer container, IRegionManager regionManager)
    {
      this.container = container;
      this.regionManager = regionManager;

      // Singleton für FeedController
      var feedController = container.Resolve<FeedController>();
      container.RegisterInstance<FeedController>(feedController);

    }

    public void Initialize()
    {
      regionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(FeedSelectionView));
      regionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(NavigateDetailsView));
      regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(NewsItemsView));
      regionManager.RegisterViewWithRegion(RegionNames.DetailsRegion, typeof(NewsDetailsView));
    }
  }
}
