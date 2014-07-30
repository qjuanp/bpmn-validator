using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q.BPMN.Validator.Enums;

namespace Q.BPMN.Validator.Models
{
    public class ValidationError
    {
        public string Message { get; set; }
        public string Id { get; set; }
        public ValidationType Type { get; set; }
        public Guid ElementId { get; set; }
        public string ElementName { get; set; }
        public string ElementXPath { get; set; }
    }
}
