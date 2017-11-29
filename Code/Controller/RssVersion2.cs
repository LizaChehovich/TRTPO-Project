using System.Xml;

namespace RSS_Reader.Controller
{
    class RssVersion2:IRssVersion
    {
        XmlNode IRssVersion.GetNode(XmlDocument rss) => rss?.FirstChild?.FirstChild;
    }
}
