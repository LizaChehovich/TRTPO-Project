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
        public delegate void NewsListReadyHandler(List<News> newsList);
        public event NewsListReadyHandler NewsListReady;

        public delegate void ExceptionHandler(string message);
        public event ExceptionHandler ExceptionTrown;

        private Profile _userProfile;
        private Filtrator _filtrator;
        private readonly Regex _regex = new Regex("\\<.*?\\>");

        public void UpdateUserProfile(Profile userProfile)
        {
            _userProfile = userProfile;
        }

        public void LoadNewses()
        {
            if(_userProfile.ResourcesList.Count==0) NewsListReady?.Invoke(new List<News>());
            CheckConnections();
            _filtrator = new Filtrator(_userProfile.IncludeFiltersList, _userProfile.ExcludeFiltersList);
            var newsList = new List<News>();
            foreach (var resource in _userProfile.ResourcesList)
            {
                newsList.AddRange(_filtrator.Filter(LoadNews(resource)));
            }
            NewsListReady?.Invoke(newsList);
        }

        private void CheckConnections()
        {
            var status = IPStatus.Unknown;
            try
            {
                status = new Ping().Send("google.com").Status;
            }
            catch (PingException )
            {
                ExceptionTrown?.Invoke(@"Нет подключения к интернету. Повторить попытку?");
            }
            if (status != IPStatus.Success)
            {
                ExceptionTrown?.Invoke(@"Нет подключения к интернету. Повторить попытку?");
            }
        }

        private List<News> LoadNews(string resource)
        {
            var document = new XmlDocument();
            document.Load(resource);
            if (!document.InnerXml.Contains("rss")) return new List<News>();
            return document.InnerXml.Contains("version=\"1.0\"") ? ParseRss1(document) : ParseRss2(document);
        }

        private List<News> ParseRss1(XmlDocument rss)
        {
            var newsList = new List<News>();
            if (rss.FirstChild == null) return newsList;
            newsList.AddRange(from XmlNode item in rss.ChildNodes[1].FirstChild.SelectNodes("item")
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

        private List<News> ParseRss2(XmlDocument rss)
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