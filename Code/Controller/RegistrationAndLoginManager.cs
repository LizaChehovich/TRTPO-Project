using System;
using System.Collections.Generic;
using RSS_Reader.Model;

namespace RSS_Reader.Controller
{
    class RegistrationAndLoginManager
    {
        private readonly FileManager _profileFileManager = new FileManager();

        public List<string> UserNameList => _profileFileManager.UserNameList;

        public User AnonymUser => GetUser(Status.Anonym.ToString(), Status.Anonym);

        public User RegisterUser(string userName)
        {
            if (NameIsBusy(userName)) throw new ArgumentException();
            var user = GetUser(userName,Status.Registered,Status.Anonym.ToString());
            _profileFileManager.SaveUserProfile(user);
            return user;
        }

        public User LogIn(string userName) => GetUser(userName, Status.Registered);

        private User GetUser(string userName, Status status, string fileName = null) => new User(userName, status, _profileFileManager.GetUserProfile(fileName ?? userName));

        private bool NameIsBusy(string name) => _profileFileManager.UserNameList.Exists(x => x.Equals(name));
    }
}