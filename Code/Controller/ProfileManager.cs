using RSS_Reader.Model;

namespace RSS_Reader.Controller
{
    class ProfileManager
    {
        public Profile Profile { get; set; }

        public bool AddResource(string resource)
        {
            if (Profile.ResourcesList.Exists(x => x.Equals(resource))) return false;
            Profile.ResourcesList.Add(resource);
            return true;
        }

        public void RemoveResource(string resource)
        {
            Profile.ResourcesList.Remove(resource);
        }

        public bool AddIncludeFilter(string includeFilter)
        {
            if (Profile.IncludeFiltersList.Exists(x => x.Equals(includeFilter))) return false;
            Profile.IncludeFiltersList.Add(includeFilter);
            return true;
        }

        public void RemoveIncludeFilter(string includeFilter)
        {
            Profile.IncludeFiltersList.Remove(includeFilter);
        }

        public bool AddExcludeFilter(string excludeFilter)
        {
            if (Profile.ExcludeFiltersList.Exists(x => x.Equals(excludeFilter))) return false;
            Profile.ExcludeFiltersList.Add(excludeFilter);
            return true;
        }

        public void RemoveExcludeFilter(string excludeFilter)
        {
            Profile.ExcludeFiltersList.Remove(excludeFilter);
        }
    }
}