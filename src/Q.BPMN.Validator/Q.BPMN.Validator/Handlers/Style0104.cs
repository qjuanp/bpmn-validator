using Q.BPMN.Validator.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Q.BPMN.Validator.Extensions;

namespace Q.BPMN.Validator.Handlers
{
    public class Style0104 : Validation
    {
        public Style0104(Validation successor)
            : base(successor)
        { }
        protected override string Id
        {
            get { return "0104"; }
        }

        protected override Enums.ValidationType Type
        {
            get { return Enums.ValidationType.Style; }
        }

        public override void Validate(Contexts.ValidationContext context)
        {
            Debug.WriteLine("Validate::{0}-{1}", Type.ToString(), Id);
            XDocument currentDocument = context.Document;

            //Obtain Process
            IEnumerable<XElement> processes = (from el in currentDocument
                                                                .Descendants(XName.Get("WorkflowProcesses", XPDLDefinition.SCHEMA))
                                                                .Descendants(XName.Get("WorkflowProcess", XPDLDefinition.SCHEMA))
                                               select el).ToList();
            //For each process analyse activities with the same name
            foreach (XElement process in processes)
            {
                IEnumerable<string> duplicatedActivities = process
                                                            .Descendants(XName.Get("Activities", XPDLDefinition.SCHEMA))
                                                            .Descendants(XName.Get("Activity", XPDLDefinition.SCHEMA))
                                                            .GroupBy(el => el.Attribute("Name").Value)
                                                            .Where(grouping => grouping.Count() > 1)
                                                            .Select(g => g.Key)
                                                            .ToList();

                foreach (string name in duplicatedActivities)
                {
                    ReportError(context, process, name);
                }
            }

            if (Successor != null) Successor.Validate(context);
        }

        private void ReportError(Contexts.ValidationContext context, XElement process, string activityName)
        {
            context.Errors.Add(new Models.ValidationError()
            {
                ElementId = new Guid(process.Attribute("Id").Value),
                ElementName = process.Attribute("Name").Value,
                ElementXPath = process.GetAbsoluteXPath(),
                Id = Id,
                Type = Type,
                Message = string.Format("In process '{0}' there is multiple activities with the name '{1}'", process.Attribute("Name").Value, activityName)
            });
        }
    }
}
