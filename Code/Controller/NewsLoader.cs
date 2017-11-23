using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Xml;
using RSS_Reader.Model;

namespace RSS_Reader.Controller
{
    class NewsLoader
    {
        private Profile _userProfile;
        private Filtrator _filtrator;
        private readonly Regex _regex = new Regex("\\<.*?\\>");

        public void UpdateUserProfile(Profile userProfile)
        {
            _userProfile = userProfile;
        }

        public List<News> LoadNewses()
        {
            if(_userProfile.ResourcesList.Count==0) return new List<News>();
            if (!CheckConnections()) return new List<News>();
            _filtrator = new Filtrator(_userProfile.IncludeFiltersList, _userProfile.ExcludeFiltersList);
            var newsList = new List<News>();
            foreach (var resource in _userProfile.ResourcesList)
            {
                newsList.AddRange(_filtrator.Filter(LoadNews(resource)));
            }
            return newsList;
        }

        private bool CheckConnections()
        {
            var status = IPStatus.Unknown;
            try
            {
                status = new Ping().Send("google.com").Status;
            }
            catch
            {
                // ignored
            }
            return status == IPStatus.Success;
        }

        private List<News> LoadNews(string resource)
        {
            var document = new XmlDocument();
            document.Load(resource);
            return document.InnerXml.Contains("rss") && document.InnerXml.Contains("version=\"2.0\"")
                ? ParseRss(document)
                : new List<News>();
        }

        private List<News> ParseRss(XmlDocument rss)
        {
            var newsList = new List<News>();
            if (rss.FirstChild == null) return newsList;
            newsList.AddRange(from XmlNode item in rss.FirstChild.FirstChild.SelectNodes("item")
                select new News
                {
                    Title = item.SelectSingleNode("title")?.InnerText,
                    Link = item.SelectSingleNode("link")?.InnerText,
                    Description = _regex.Replace(item.SelectSingleNode("description").InnerText, ""),
                    Category = item.SelectSingleNode("category")?.InnerText,
                    PublicationDate = item.SelectSingleNode("pubDate")?.InnerText
                });
            return newsList;
        }
    }
}