using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Q.BPMN.Validator.Models;

namespace Q.BPMN.Validator.Contexts
{
    public class Context
    {
        public string FileName { get; set; }
        public XDocument Document { get; set; }
        public ProcessModel Model { get; set; }
        public Context(string fileName, XDocument document)
        {
            Document = document;
            FileName = fileName;
            Model = new ProcessModel(document);
        }
    }
}
