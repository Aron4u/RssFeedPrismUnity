using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RssFeedBL
{
  public class FeedController
  {
    public List<FeedParams> GetFeeds()
    {
      var feeds = new List<FeedParams>();
      feeds.Add(new FeedParams { Name = "Spiegel online", Url = "http://www.spiegel.de/schlagzeilen/tops/index.rss" });
      feeds.Add(new FeedParams { Name = "Spiegel Reisen", Url = "http://www.spiegel.de/reise/index.rss" });
      feeds.Add(new FeedParams { Name = "MSDN Aktuell", Url = "http://www.microsoft.com/germany/msdn/rss/aktuell.xml" });
      return feeds;
    }
    public SyndicationFeed LoadFeed(FeedParams feed)
    {
      XmlReader reader = XmlReader.Create(feed.Url);
      return  SyndicationFeed.Load(reader);
    }


  }
}
