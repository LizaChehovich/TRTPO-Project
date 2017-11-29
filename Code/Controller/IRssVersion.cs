using System.Collections.Generic;
using System.Xml;
using RSS_Reader.Model;

namespace RSS_Reader.Controller
{
    interface IRssVersion
    {
        XmlNode GetNode(XmlDocument rss);
    }
}
