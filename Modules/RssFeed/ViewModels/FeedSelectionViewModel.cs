using System.Collections.Generic;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using RssFeedBL;
using RssInfrastructure;

namespace RssFeed.ViewModels
{
  public class FeedSelectionViewModel : ViewModelBase
  {

    public IEnumerable<FeedParams> Feeds { get; set; }

    private FeedParams selectedFeed;

    public FeedParams SelectedFeed
    {
      get { return selectedFeed; }
      set
      {
        selectedFeed = value;
        eventAggregator.GetEvent<FeedSelectedEvent>().Publish(selectedFeed);
      }
    }

    private IEventAggregator eventAggregator;

    public FeedSelectionViewModel(IUnityContainer container, IEventAggregator eventAggregator)
    {
      var feedController = container.Resolve<FeedController>();
      Feeds = feedController.GetFeeds();
      this.eventAggregator = eventAggregator;
    }
  }
}
