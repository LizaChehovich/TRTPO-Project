using System.Collections.Generic;
using System.Linq;
using RSS_Reader.Model;

namespace RSS_Reader.Controller
{
    class Filtrator
    {
        private readonly IReadOnlyCollection<string> _includeFiltersList;
        private readonly IReadOnlyCollection<string> _excludeFiltersList;

        public Filtrator(IReadOnlyCollection<string> includeFiltersList, IReadOnlyCollection<string> excludeFiltersList)
        {
            _includeFiltersList = includeFiltersList;
            _excludeFiltersList = excludeFiltersList;
        }

        public List<News> Filter(List<News> newsForFilter)
        {
            if (newsForFilter.Count == 0) return newsForFilter;
            var includeNewsList = FilterByIncludes(newsForFilter);
            return FilterByExcludes(includeNewsList);
        }

        private List<News> FilterByIncludes(List<News> newsForFilter)
        {
            if (_includeFiltersList.Count == 0 || newsForFilter.Count == 0) return newsForFilter;
            return newsForFilter.Where(news => NewsContainsFilter(news, _includeFiltersList.ToList())).ToList();
        }

        private List<News> FilterByExcludes(List<News> newsForFilter)
        {
            if (_excludeFiltersList.Count == 0 || newsForFilter.Count == 0) return newsForFilter;
            return newsForFilter.Where(news => !NewsContainsFilter(news, _excludeFiltersList.ToList())).ToList();
        }

        private bool NewsContainsFilter(News news, List<string> filtersList)
        {
            return filtersList.Any(filter =>
                news.Title.Contains(filter) || news.Description.Contains(filter) || news.Category.Contains(filter));
        }
    }
}
