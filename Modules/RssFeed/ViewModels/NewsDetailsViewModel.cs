using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.PubSubEvents;
using RssInfrastructure;

namespace RssFeed.ViewModels
{
  public class NewsDetailsViewModel:ViewModelBase
  {
    public NewsDetailsViewModel(IEventAggregator eventAggregator)
    {
      eventAggregator.GetEvent<NewsItemSelectedEvent>().Subscribe(NewsItemSelected);
    }

    private SyndicationItem item;

    public SyndicationItem Item
    {
      get { return item; }
      set { this.SetProperty<SyndicationItem>(ref item, value); }
    }
    private void NewsItemSelected(SyndicationItem newsItem)
    {
      Item = newsItem;
    }
  }
}
