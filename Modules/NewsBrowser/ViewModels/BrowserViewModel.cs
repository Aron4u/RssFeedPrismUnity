using System;
using System.ServiceModel.Syndication;
using Microsoft.Practices.Prism.PubSubEvents;
using MVVM_Utilities;
using RssInfrastructure;

namespace NewsBrowser.ViewModels
{
  public class BrowserViewModel : ViewModelBase
  {
    public Uri NewsSiteUri { get; set; }

    private IEventAggregator eventAggregator;

    public BrowserViewModel(IEventAggregator eventAggregator)
    {
      this.eventAggregator = eventAggregator;
      eventAggregator.GetEvent<NewsItemSelectedEvent>().Subscribe(NewsItemSelected);
    }

    private void NewsItemSelected(SyndicationItem item)
    {

      if (item != null)
        NewsSiteUri = item.Links[0].Uri;
      else
        NewsSiteUri = null;
      if (this.IsActive)
        OnPropertyChanged(() => NewsSiteUri);
    }

    public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
    {
      OnPropertyChanged(() => NewsSiteUri);
    }
  }
}
