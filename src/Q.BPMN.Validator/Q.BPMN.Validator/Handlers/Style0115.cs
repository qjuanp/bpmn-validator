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
    public class Style0115 : Validation
    {
        public Style0115(Validation successor)
            : base(successor)
        { }
        protected override string Id
        {
            get { return "0115"; }
        }

        protected override Enums.ValidationType Type
        {
            get { return Enums.ValidationType.Style; }
        }

        public override void Validate(Contexts.ValidationContext context)
        {
            Debug.WriteLine("Validate::{0}-{1}", Type.ToString(), Id);
            XDocument currentDocument = context.Document;

            var queryThrowMessages = from el in currentDocument
                                        .Descendants(XName.Get("TriggerResultMessage", XPDLDefinition.SCHEMA))
                                     where el.HasAttributes && el.Attribute("CatchThrow").Value == "THROW"
                                     select el;

            var queryActivity = from el in queryThrowMessages
                                from ancestor in el.Ancestors(XName.Get("Activity", XPDLDefinition.SCHEMA))
                                where ancestor.Attribute("Name").Value == string.Empty
                                select ancestor;

            if (queryActivity.Count() > 0) ReportError(context, queryActivity.First());

            if (Successor != null) Successor.Validate(context);
        }

        private void ReportError(Contexts.ValidationContext context, XElement activity)
        {
            context.Errors.Add(new Models.ValidationError()
            {
                ElementId = new Guid(activity.Attribute("Id").Value),
                ElementName = activity.Attribute("Name").Value,
                ElementXPath = activity.GetAbsoluteXPath(),
                Id = Id,
                Type = Type,
                Message = string.Format("The activity with Id '{0}' should have a name!", activity.Attribute("Id").Value)
            });
        }
    }
}
