using System.Collections.Generic;

namespace RSS_Reader.Model
{
    class Profile
    {
        public List<string> ResourcesList { get; set; }
        public List<string> IncludeFiltersList { get; set; }
        public List<string> ExcludeFiltersList { get; set; }
    }
}
