namespace RSS_Reader.Model
{
    public class User
    {
        public string Name { get;}
        public Status Status { get;}

        private Profile _profile;

        public Profile Profile
        {
            get=> _profile;
            set => _profile = value ?? new Profile();
        }

        public User(string name, Status status, Profile profile)
        {
            Name = name;
            Status = status;
            Profile = profile;
        }
    }
}
