using System;
using System.ServiceModel.Syndication;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using MVVM_Utilities;
using RssInfrastructure;

namespace NewsBrowser.ViewModels
{
  public class NavigateBrowserViewModel:ViewModelBase
  {
    public DelegateCommand ShowBrowserCommand { get; set; }

    private Uri selectedUri;
    private IRegionManager regionManager;

   

    private void ShowBrowser()
    {
      regionManager.RequestNavigate(RegionNames.DetailsRegion, "BrowserView");
    }

    public NavigateBrowserViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
    {
      ShowBrowserCommand = new DelegateCommand(ShowBrowser, () => selectedUri != null);
      eventAggregator.GetEvent<NewsItemSelectedEvent>().Subscribe(SelectionChanged);
      this.regionManager = regionManager;
    }

    private void SelectionChanged(SyndicationItem item)
    {
      if (item == null)
        selectedUri = null;
      else
        selectedUri = item.Links[0].Uri;
      ShowBrowserCommand.RaiseCanExecuteChanged();
    }
  }
}
