using System.Collections.Generic;
using System.Xml;
using RSS_Reader.Model;

namespace RSS_Reader.Controller
{
    abstract class RssVersion
    {
        public static RssVersion GetVersion(int number) => number == 1 ? (RssVersion)new RssVersion1() : new RssVersion2();

        public abstract XmlNode GetNode(XmlDocument rss);
    }
}
