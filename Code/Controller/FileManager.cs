using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using RSS_Reader.Model;

namespace RSS_Reader.Controller
{
    class FileManager
    {
        private readonly string _rootName = @"profile";
        private readonly string[] _resourcesParameters = {@"resources", @"resource"};
        private readonly string[] _includesParameters = {@"includes", @"include"};
        private readonly string[] _excludesParameters = {@"exclude", @"exclude"};
        private readonly string _relativeAddress = @"..\..\Users";
        private readonly string _fileExtension = @".xml";

        public List<string> GetUserNameList()
        {
            List<string> userNameList = new List<string>();
            foreach (var filePath in Directory.GetFiles(_relativeAddress, @"*" + _fileExtension))
            {
                var fileName = Path.GetFileName(filePath);
                if(fileName.Equals("Anonym.xml")) continue;
                userNameList.Add(fileName.Remove(fileName.Length - 4));
            }
            return userNameList;
        }

        public Profile GetUserProfile(string userName)
        {
            var xDocument = XDocument.Load(new StringReader(File.ReadAllText(GetPathToFile(userName))));
            return new Profile
            {
                ResourcesList = XElementToInformationList(_rootName, _resourcesParameters, xDocument),
                IncludeFiltersList = XElementToInformationList(_rootName, _includesParameters, xDocument),
                ExcludeFiltersList = XElementToInformationList(_rootName, _excludesParameters, xDocument)
            };
        }

        public void SaveUserProfile(User user)
        {
            new XDocument(new XElement(_rootName, GetXElement(_resourcesParameters, user.Profile.ResourcesList),
                GetXElement(_includesParameters, user.Profile.IncludeFiltersList),
                GetXElement(_excludesParameters, user.Profile.ExcludeFiltersList))).Save(GetPathToFile(user.Name));
        }

        private XElement GetXElement(string[] parameters, List<string> informationList)
        {
            var xElement = new XElement(parameters[0]);
            foreach (var information in informationList)
            {
                xElement.Add(new XElement(parameters[1], information));
            }
            return xElement;
        }

        private List<string> XElementToInformationList(string rootName, string[] parameters, XDocument xDocument)
        {
            var informationList = new List<string>();
            foreach (var informationElement in xDocument.Elements(rootName).Elements(parameters[0])
                .Elements(parameters[1]))
            {
                informationList.Add(informationElement.Value);
            }
            return informationList;
        }

        private string GetPathToFile(string fileName)
        {
            return _relativeAddress + fileName + _fileExtension;
        }
    }
}