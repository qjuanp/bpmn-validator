using Q.BPMN.Validator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Q.BPMN.Validator.Models
{
    public class ProcessModel
    {
        public string XPDLVersion { get; set; }
        public DateTime Created { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string Contry { get; set; }

        public ProcessModel(XDocument document)
        {
            var queryName = from pk in document.Elements()
                            where pk.Name.LocalName == "Package"
                            select new
                            {
                                Id = new Guid(pk.Attribute("Id").Value),
                                Name = pk.Attribute("Name").Value
                            };

            var queryPackage = from pk in document.Descendants(XName.Get("PackageHeader", XPDLDefinition.SCHEMA))
                               select new
                               {
                                   XPDLVersion = pk.Element(XName.Get("XPDLVersion", XPDLDefinition.SCHEMA)).Value,
                                   Created = Convert.ToDateTime(pk.Element(XName.Get("Created", XPDLDefinition.SCHEMA)).Value),
                                   Description = pk.Element(XName.Get("Description", XPDLDefinition.SCHEMA)).Value
                               };
            var queryRefinableHeader = from pk in document.Descendants(XName.Get("RedefinableHeader", XPDLDefinition.SCHEMA))
                               select new
                               {
                                   Author = pk.Element(XName.Get("Author", XPDLDefinition.SCHEMA)).Value,
                                   Version = pk.Element(XName.Get("Version", XPDLDefinition.SCHEMA)).Value,
                                   CountryKey = pk.Element(XName.Get("Countrykey", XPDLDefinition.SCHEMA)).Value
                               };


            Id = queryName.First().Id;
            Name = queryName.First().Name;

            XPDLVersion = queryPackage.First().XPDLVersion;
            Created = queryPackage.First().Created;
            Description = queryPackage.First().Description;

            Author = queryRefinableHeader.First().Author;
            Version = queryRefinableHeader.First().Version;
            Contry = queryRefinableHeader.First().CountryKey;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", Id, Name, Description, Author);
        }
    }
}
