using System;
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
        private readonly Regex _descriptionRegex = new Regex("\\<.*?\\>");
        private readonly Regex _versionRegex = new Regex("(?<=version=\")(.{1})");
        private RssVersion _rssVersion;

        private void ChangeRssVersion(int version)
        {
            _rssVersion = RssVersion.GetVersion(version);
        }

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
            IPStatus status;
            try
            {
                status = new Ping().Send("google.com").Status;
            }
            catch (PingException )
            {
                status = IPStatus.Unknown;
            }
            if (status != IPStatus.Success)
            {
                ExceptionTrown?.Invoke(@"Нет подключения к интернету. Повторить попытку?");
            }
        }

        private List<News> LoadNews(string resource)
        {
            var document = new XmlDocument();
            try
            {
                document.Load(resource);
            }
            catch (Exception)
            {
                return new List<News>();
            }
            if (!document.InnerXml.Contains("rss")) return new List<News>();
            ChangeRssVersion(Convert.ToInt32(_versionRegex.Match(document.InnerXml).Value));
            return ParseRss(_rssVersion.GetNode(document));
        }

        private List<News> ParseRss(XmlNode node)
        {
            var newsList = new List<News>();
            newsList.AddRange(from XmlNode item in node?.SelectNodes("item")
                select new News(item.SelectSingleNode("title")?.InnerText, item.SelectSingleNode("link")?.InnerText,
                    _descriptionRegex.Replace(item.SelectSingleNode("description")?.InnerText ?? string.Empty, ""),
                    item.SelectSingleNode("category")?.InnerText, item.SelectSingleNode("pubDate")?.InnerText));
            return newsList;
        }
    }
}