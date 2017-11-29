using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly string _relativeAddress = @"..\..\Users\";
        private readonly string _fileExtension = @".xml";

        public List<string> UserNameList =>
        (from filePath in Directory.GetFiles(_relativeAddress, @"*" + _fileExtension)
            select Path.GetFileName(filePath)
            into fileName
            where !fileName.Equals("Anonym.xml")
            select fileName.Remove(fileName.Length - _fileExtension.Length)).ToList();

        public Profile GetUserProfile(string userName)
        {
            var xDocument = XDocument.Load(new StringReader(File.ReadAllText(GetPathToFile(userName))));
            var profile = new Profile();
            profile.AddResources(XElementToInformationList(_rootName, _resourcesParameters, xDocument));
            profile.AddIncludeFilters(XElementToInformationList(_rootName, _includesParameters, xDocument));
            profile.AddExcludeFilters(XElementToInformationList(_rootName, _excludesParameters, xDocument));
            return profile;
        }

        public void SaveUserProfile(User user) => new XDocument(new XElement(_rootName, GetXElement(_resourcesParameters, user.Profile.ResourcesList),
                GetXElement(_includesParameters, user.Profile.IncludeFiltersList),
                GetXElement(_excludesParameters, user.Profile.ExcludeFiltersList))).Save(GetPathToFile(user.Name));

        private XElement GetXElement(string[] parameters, IReadOnlyCollection<string> informationList)
        {
            var xElement = new XElement(parameters[0]);
            foreach (var information in informationList)
            {
                xElement.Add(new XElement(parameters[1], information));
            }
            return xElement;
        }

        private List<string> XElementToInformationList(string rootName, string[] parameters, XDocument xDocument) => xDocument.Elements(rootName)
                .Elements(parameters[0])
                .Elements(parameters[1])
                .Select(informationElement => informationElement.Value)
                .ToList();

        private string GetPathToFile(string fileName) => _relativeAddress + fileName + _fileExtension;
    }
}