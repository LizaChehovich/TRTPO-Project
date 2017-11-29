using System.Xml;

namespace RSS_Reader.Controller
{
    class RssVersion1: RssVersion
    {
        public override XmlNode GetNode(XmlDocument rss) => rss?.ChildNodes[1]?.FirstChild;
    }
}
