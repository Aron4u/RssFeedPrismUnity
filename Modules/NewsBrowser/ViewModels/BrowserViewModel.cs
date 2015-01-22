using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.PubSubEvents;
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
