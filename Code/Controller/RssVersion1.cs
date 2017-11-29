using System.Xml;

namespace RSS_Reader.Controller
{
    class RssVersion1: IRssVersion
    {
        XmlNode IRssVersion.GetNode(XmlDocument rss) => rss?.ChildNodes[1]?.FirstChild;
    }
}
