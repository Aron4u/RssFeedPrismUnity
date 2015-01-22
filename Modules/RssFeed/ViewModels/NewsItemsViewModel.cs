using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using RssFeedBL;
using RssInfrastructure;

namespace RssFeed.ViewModels
{
  public class NewsItemsViewModel : ViewModelBase
  {
    private SyndicationFeed feed;

    public SyndicationFeed Feed
    {
      get { return feed; }
      set { this.SetProperty<SyndicationFeed>(ref feed, value); }
    }

    private SyndicationItem selectedItem;

    public SyndicationItem SelectedItem
    {
      get { return selectedItem; }
      set
      {
        selectedItem = value;
        eventAggregator.GetEvent<NewsItemSelectedEvent>().Publish(selectedItem);
      }
    }

    private IEventAggregator eventAggregator;
    private IUnityContainer container;

    public NewsItemsViewModel(IEventAggregator eventAggregator, IUnityContainer container)
    {
      this.eventAggregator = eventAggregator;
      this.container = container;
      eventAggregator.GetEvent<FeedSelectedEvent>().Subscribe(ReadFeed);
    }

    private void ReadFeed(FeedParams feedParams)
    {
      var feedController = container.Resolve<FeedController>();
      Feed = feedController.LoadFeed(feedParams);
    }
  }
}
