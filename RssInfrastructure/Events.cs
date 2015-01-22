using System.ServiceModel.Syndication;
using Microsoft.Practices.Prism.PubSubEvents;
using RssFeedBL;

namespace RssInfrastructure
{
  public class FeedSelectedEvent : PubSubEvent<FeedParams> { }
  public class NewsItemSelectedEvent : PubSubEvent<SyndicationItem> { }

}
