using System.Xml;

namespace RSS_Reader.Controller
{
    class RssVersion2: RssVersion
    {
        public override XmlNode GetNode(XmlDocument rss) => rss?.FirstChild?.FirstChild;
    }
}
