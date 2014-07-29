using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Q.BPMN.Validator.Models;

namespace Q.BPMN.Validator.Contexts
{
    public class ValidationContext : Context
    {
        public bool IsValid { get; set; }
        public IList<ValidationError> Errors { get; set; }

        public ValidationContext(string fileName, XDocument document)
            : base(fileName, document)
        {
            IsValid = false;
            Errors = new List<ValidationError>();
        }
    }
}
