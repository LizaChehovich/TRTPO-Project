using System.Deployment.Application;

namespace RSS_Reader.Model
{
    public class User
    {
        public string Name { get;}
        public Status Status { get;}
        public Profile Profile { get; set; }

        public User(string name, Status status, Profile profile)
        {
            Name = name;
            Status = status;
            Profile = profile;
        }
    }
}
