using System.Collections.Generic;

namespace RSS_Reader.Model
{
    public class Profile
    {
        private readonly List<string> _resourcesList = new List<string>();
        private readonly List<string> _includeFiltersList = new List<string>();
        private readonly List<string> _excludeFiltersList = new List<string>();

        public IReadOnlyCollection<string> ResourcesList => _resourcesList.AsReadOnly();
        public IReadOnlyCollection<string> IncludeFiltersList => _includeFiltersList.AsReadOnly();
        public IReadOnlyCollection<string> ExcludeFiltersList => _excludeFiltersList.AsReadOnly();

        public bool AddResource(string resource)
        {
            if (_resourcesList.Exists(x => x.Equals(resource))) return false;
            _resourcesList.Add(resource);
            return true;
        }

        public void AddResources(IEnumerable<string> resourcesList)
        {
            foreach (var resource in resourcesList)
            {
                AddResource(resource);
            }
        }

        public void RemoveResourse(string resource)
        {
            _resourcesList.Remove(resource);
        }

        public bool AddIncludeFilter(string includeFilter)
        {
            if (FilterExist(includeFilter)) return false;
            _includeFiltersList.Add(includeFilter);
            return true;
        }

        public void AddIncludeFilters(IEnumerable<string> includeFiltersList)
        {
            foreach (var includeFilter in includeFiltersList)
            {
                AddIncludeFilter(includeFilter);
            }
        }

        public void RemoveIncludeFilter(string includeFilter)
        {
            _includeFiltersList.Remove(includeFilter);
        }

        public bool AddExcludeFilter(string excludeFilter)
        {
            if (FilterExist(excludeFilter)) return false;
            _excludeFiltersList.Add(excludeFilter);
            return true;
        }

        public void AddExcludeFilters(IEnumerable<string> excludeFilterList)
        {
            foreach (var excludeFilter in excludeFilterList)
            {
                AddExcludeFilter(excludeFilter);
            }
        }

        public void RemoveExcludeFilter(string excludeFilter)
        {
            _excludeFiltersList.Remove(excludeFilter);
        }

        private bool FilterExist(string filter) => _includeFiltersList.Exists(x => x.Equals(filter)) ||
                                                   _excludeFiltersList.Exists(x => x.Equals(filter));
    }
}