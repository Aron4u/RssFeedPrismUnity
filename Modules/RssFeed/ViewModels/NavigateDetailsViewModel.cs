using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using RssInfrastructure;

namespace RssFeed.ViewModels
{
  public class NavigateDetailsViewModel:ViewModelBase
  {
       public DelegateCommand ShowDetailsCommand { get; set; }

    private Uri selectedUri;
    private IRegionManager regionManager;

   

    private void ShowBrowser()
    {
      regionManager.RequestNavigate(RegionNames.DetailsRegion, "NewsDetailsView");
    }

    public NavigateDetailsViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
    {
      ShowDetailsCommand = new DelegateCommand(ShowBrowser, () => selectedUri != null);
      eventAggregator.GetEvent<NewsItemSelectedEvent>().Subscribe(SelectionChanged);
      this.regionManager = regionManager;
    }

    private void SelectionChanged(SyndicationItem item)
    {
      if (item == null)
        selectedUri = null;
      else
        selectedUri = item.Links[0].Uri;
      ShowDetailsCommand.RaiseCanExecuteChanged();
    }
  }
}
